
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <stdlib.h>
#include <pthread.h>



//FUNCIONES PARA LISTA CONECTADOS

typedef struct{
	char nombre [20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;//sie n la lista hay 5 conectados, de 0 a 4 el siguiente es el 5
	
} ListaConectados;
char nick[20];
char passw[20];

int PonConectado (ListaConectados *lista, char nombre[20], int socket){
	/*A￯﾿ﾯ￯ﾾ﾿￯ﾾﾱade nuevp conectados. retorna 0 si ok y -1 si la 
	lista ya estaba llena y no lo ha podido hacer
	*/
	if (lista->num == 100)
		return -1;
	else {
		strcpy (lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
}

int DamePosicion (ListaConectados *lista, char nombre[20]){
	//devuelve la posicion en la lista o -1 si no est￯﾿ﾯ￯ﾾ﾿￯ﾾﾡ ne la lista
	int i=0;
	int encontrado=0;
	while ((i< lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre)==0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
		
		
	}
	if (encontrado)
		return i;
	else
		return -1;
	
}

int Elimina (ListaConectados *lista, char nombre[20])
	//retorna 0 si elimina y -1 si ese usuario no est￯﾿ﾯ￯ﾾ﾿￯ﾾﾡ en la lista
{
	int pos = DamePosicion (lista, nombre);//no lleva a mbersand ya que ya he recibido la lista por referencia, *lista del main ya es un puntero
	if (pos==-1)
		return -1;
	else{
		int i;
		for  (i=pos; i< lista->num-1; i++)
		{
			lista->conectados[i] = lista->conectados[i+1];
			//strcpy(lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			//lista->conectados[i].socket = lista->conectados[i+1].socket;
		}
		lista->num--;
		return 0;
	}
}

void DameConectados (ListaConectados *lista, char conectados[300])
{// pone en conectados los niombres de todos los conectados separados por "/". Primero pone el numero de conectados
	sprintf(conectados, "4/%d/", lista->num);
	int i;
	for (i = 0; i < lista->num; i++)
		sprintf(conectados, "%s%s/", conectados, lista->conectados[i].nombre);
	
	conectados[strlen(conectados) - 1] = '\0';
	strcat(conectados, "/");	
}


int Registrarse (char nick[20], char passw[20])
{
	
	MYSQL *conn;
	int err;
	
	//Creamos una conexion
	conn = mysql_init(NULL);
	if (conn == NULL)
	{
		printf ("Error al crear la conexion \n: %u %s \n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	//Inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root","mysql","CM_BD",0,NULL,0);
	if (conn == NULL)
	{
		printf ("Error al inicialiazar la conexion \n: %u %s", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	//CONSULTA SQL
	char consulta [512];
	sprintf(consulta, "INSERT INTO jugadores (Nickname, Contrase￯﾿ﾱa) VALUES ('%s','%s')", nick, passw);
	err = mysql_query (conn, consulta);
	
	int encontrado = 0;
	if (err != 0)
	{
		printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	else
		encontrado = 1;
	
	//Cerrar la conexion
	mysql_close(conn);
	return encontrado;
	exit(0);
}


int contador;


//VARIABLES GLOBALES
//estructura para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];
ListaConectados miLista;


void *AtenderCliente (void *socket)
{
	
	
	//inizializamos conexion con la base de datos
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexin
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "CM_BD",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	
	int terminar =0;
	//entramos en bucle para atender a todas las peticiones de este cliente hasta que se desconecte
	
	
	while (terminar ==0)
	{
		
		// Ahora recibimos su peticion
		ret=read(sock_conn,peticion, sizeof(peticion)); //guarda en petici￯﾿ﾯ￯ﾾ﾿￯ﾾﾳn, vector de caracteres
		printf ("Recibida una peticion\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		//Escribimos la peticion en la consola
		
		printf ("La peticion es: %s\n",peticion);
		
		char *p = strtok(peticion, "/");//arrancar numero (puntero )
		int codigo =  atoi (p);//convierte en entero y introduce en codigo
		
		
		
		if (codigo ==0)
			terminar=1;
		
		
		
		else if (codigo ==1) //log in
		{
			char nick[20];
			p = strtok( NULL, "/");
			strcpy(nick, p);
			char passw[20];
			p = strtok(NULL, "/");
			strcpy(passw, p);
			char consulta[100];
			
			
			sprintf(consulta, "SELECT jugadores.Nickname FROM jugadores WHERE jugadores.Nickname = '%s' AND jugadores.Password = '%s'", nick, passw);
			
			err=mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			
			printf("consulta: %s\n",consulta);
			
			err= mysql_query (conn, consulta);
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			
			if (row == NULL)
				sprintf(respuesta, "1/NO");
			else
			{
				pthread_mutex_lock (&mutex);//no interrumpas ahora
				int res = PonConectado(&miLista, nick, sock_conn);
				pthread_mutex_unlock ( &mutex); 
				
				if (res == 0)
				{ printf("%s ha sido a￱adido a la lista de usuarios\n", nick); }
				
				strcpy(respuesta, "1/SI");
				printf ("Respuesta: %s\n", respuesta);
				char conectados [300];
				DameConectados (&miLista, conectados);
				printf("lista de conectados: %s\n", conectados);
				for (i=0; i < miLista.num; i++)
					write (miLista.conectados[i].socket, conectados, strlen(conectados));
			}
			write (sock_conn,respuesta , strlen(respuesta));	
			
		}
		//consulta marc consulta marc consulta marc
		else if (codigo ==2)
		{
			char fecha[30];
			p = strtok(NULL, "/"); 
			strcpy(fecha,p);
			
			char consulta[500];
			char nombres[50];
			
			sprintf (consulta, "SELECT jugadores.Nickname FROM jugadores,partidas,datos WHERE partidas.Fecha = '%s' AND partidas.id=datos.idP AND (datos.idJ1 = jugadores.id OR datos.idJ2 = jugadores.id)",fecha);
			
			err= mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			printf("consulta: %s\n",consulta);
			
			
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			
			if (row == NULL)
			{
				sprintf (respuesta, "2/NO");
				
				
				
				
			}
			else 
			{
				while (row!=NULL) 
				{
					sprintf (nombres, row[0]);
					row = mysql_fetch_row(resultado);
					sprintf(resultado, "%s%s/ \n", resultado, nombres);
				}
				sprintf (respuesta, "2/%s",resultado);
				
				
			}		
			write (sock_conn,respuesta, strlen(respuesta));
			
			
		}
		else if (codigo==3)//SEGUNDA CONSULTA
		{
			
			char nick[30];
			p = strtok(NULL, "/"); 
			strcpy(nick, p);
			char consulta[512];
			
			
			
			
			printf("el nick seleccionado es: '%s'\n", nick);
			
			
			sprintf (consulta, "SELECT SUM(partidas.Duracion) FROM (partidas) WHERE partidas.Ganador = '%s'",nick);
			
			err= mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			printf("consulta: %s\n",consulta);
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			
			
			char suma [50];
			
			if (row[0] == NULL || row[1]==NULL)
			{
				sprintf (respuesta, "3/NO");
			}
			
			
			
			else{
				sprintf (suma, row[0]);
				
				sprintf (respuesta, "3/%s", suma);
			}
			
			write (sock_conn,respuesta, strlen(respuesta));
			
			
			
		}
		
		else if (codigo== 4)
		{
			p = strtok(NULL, "/");
			strcpy(nick, p);
			p = strtok(NULL, "/");
			strcpy(passw, p);
			printf("Nickname: %s Contrase￱a: %s \n", nick, passw);
			
			int res = Registrarse(nick, passw);
			if (res == 1)
				strcpy(respuesta, "2/Existe");
			else
			{
				int encontrado = Registrarse(nick, passw);
				if (encontrado == 1)
					strcpy(respuesta, "4/Si");
				else
					strcpy(respuesta, "4/No");
			}
			// Enviamos la respuesta
			write (sock_conn,respuesta , strlen(respuesta));
		}
	
	
		
	
	
	if ((codigo==1)||(codigo==2))
	{
		pthread_mutex_lock (&mutex);//no interrumpas ahora
		contador=contador+1;
		pthread_mutex_unlock ( &mutex); //puedes interrumpir
		
		//notificar a clientes conectados
		char notificacion[20];
		sprintf (notificacion, "6/%d", contador);
		
		int j;
		for (j=0; j< i; j++)
		{
			write (sockets[j],notificacion, strlen(notificacion));
		}
		
	}
	}
		

close(sock_conn); 
}



int main(int argc, char **argv)
{	
	
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
	{
		printf("Error creant socket");
	}
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
		
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9050);//puertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuerto
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	
	contador =0;
	
	pthread_t thread; //creo la estuctura de threads y declaro un vector de threads, en creador de threads incluyo el que estamos usando ahora
	i=0;
	// Atenderemos solo 10 peticione
	for(;;){ 
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
	}
	
	
}

	