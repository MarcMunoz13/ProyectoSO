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



//VARIABLES GLOBALES
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i;
int sockets[100];
ListaConectados miLista;

MYSQL *conn;
int err;
MYSQL_RES *resultado;
MYSQL_ROW row;

char consulta [512];
char respuesta [512];
char nick[20]; 

int contador;

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

int DamePosicion (ListaConectados *lista, int socket){
	//devuelve la posicion en la lista o -1 si no est￯﾿ﾯ￯ﾾ﾿￯ﾾﾡ ne la lista
	int i=0;
	int encontrado=0;
	while ((i< lista->num) && !encontrado)
	{
		if (lista->conectados[i].socket==socket)
			encontrado =1;
		if (!encontrado)
			i++;
		
		
	}
	if (encontrado)
		return i;
	else
		return -1;
	
}

void DameConectados (ListaConectados *lista, char conectados[300])
{// pone en conectados los niombres de todos los conectados separados por "/". Primero pone el numero de conectados
	sprintf(conectados, "%d/", lista->num);
	int i;
	for (i = 0; i < lista->num; i++)
		sprintf(conectados, "%s%s/", conectados, lista->conectados[i].nombre);
	
	conectados[strlen(conectados) - 1] = '\0';
	strcat(conectados, "/");	
}

int id = 0;

int Registrarse (char nick[20], char passw[20], char respuesta[20])
{
	
	char consulta [512];
	
	sprintf(consulta, "SELECT jugadores.Nickname FROM jugadores WHERE jugadores.Nickname = '%s'", nick);
	err = mysql_query (conn, consulta);
	printf("El nombre y contrase￱a son: %s, %s\n" ,nick, passw);
	if (err != 0)
	{
		printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	resultado = mysql_store_result (conn);
	row=mysql_fetch_row(resultado);
	
	if (row == NULL)
	{
		sprintf(consulta, "SELECT MAX(jugadores.id) FROM (jugadores)");
		err = mysql_query (conn, consulta);
		if (err != 0)
		{
			printf("hola\n");
			printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
			exit(1);
		}
		resultado = mysql_store_result (conn);
		row=mysql_fetch_row(resultado);
		
		int id = atoi(row[0])+1;
		printf("%d\n", id);
		sprintf(consulta, "INSERT INTO jugadores (id, Nickname, Password) VALUES (%d,'%s','%s')",id, nick, passw);
		printf("%s\n", consulta);
		err = mysql_query (conn, consulta);
		printf("el nombre y contrase￯﾿ﾱa son: %s, %s\n" ,nick, passw);
		if (err != 0)
		{
			printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
			exit(1);
		}
		
		sprintf(respuesta, "0");
	}
	else
	{
		sprintf(respuesta, "-1");
	}
}


void *AtenderCliente (void *socket)
{
	
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
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
	
	
	int terminar =0;
	//entramos en bucle para atender a todas las peticiones de este cliente hasta que se desconecte
	
	while (terminar ==0)
	{
		
		// Ahora recibimos su peticion
		ret=read(sock_conn,peticion, sizeof(peticion)); //guarda en petici￯﾿ﾳn, vector de caracteres
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
		
	
//-------------------------------------------------LOG IN-------------------------------------------------------------------		
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
			
			//err=mysql_query (conn, consulta);
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
			{	
				sprintf(respuesta, "NO");
			}
			else
			{
				
			
				pthread_mutex_lock (&mutex);//no interrumpas ahora
				int res = PonConectado(&miLista, nick, sock_conn);
				pthread_mutex_unlock ( &mutex); //puedes interrumpir

				if (res == 0)
				{ 
					printf("%s ha sido a￱adido a la lista de usuarios conectados\n", nick); 
				}
				strcpy(respuesta, "SI");
			}
			printf ("Respuesta:00 %s\n", respuesta);
			// Enviamos la respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
//--------------------------------Consulta QUE JUGADORES JUGARON ESTE DￍA------------------------------------------------
		else if (codigo ==2)
		{
			
			char fecha[30];
			p = strtok(NULL, "/"); 
			strcpy(fecha,p);
			
			char consulta[500];
			char nombres[50];
			
			sprintf (consulta, "SELECT jugadores.Nickname FROM jugadores,partidas,datos WHERE partidas.Fecha = '%s' AND partidas.id=datos.idP AND (datos.idJ1 = jugadores.id OR datos.idJ2 = jugadores.id)",fecha);
			
			printf("guarro-");
			
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
				sprintf (resultado, "NO");
			
			else 
			{
				while (row!=NULL) 
				{
					sprintf (nombres, row[0]);
					row = mysql_fetch_row(resultado);
					sprintf(resultado, "%s%s/ \n", resultado, nombres);
				}
			}		
			write (sock_conn,resultado, strlen(resultado));
			
			
		}
		
//------------------------------------------Consulta Duraci￳n total partidas----------------------------------------------------
		else if (codigo ==3)
		{
			
			
			char nick[30];
			p = strtok(NULL, "/"); 
			strcpy(nick, p);
			
			
			
		
			
			printf("el nick seleccionado es: '%s'\n", nick);
			
			
			sprintf (consulta, "SELECT SUM(partidas.Duracion) FROM (partidas) WHERE partidas.Ganador = '%s'",nick);
			
			
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			printf("consulta: %s\n",consulta);
			
			err= mysql_query (conn, consulta);
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			if (row[0]==NULL)
				sprintf (respuesta, "NO");
				
				
			else 
				sprintf (respuesta, row[0]);
		
			
			printf("2%s", respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		else if (codigo== 4)//pide lista conectados
		{
			
			char conectados [300];
			DameConectados (&miLista, conectados);
			printf("lista de conectados: %s\n", conectados);
			
			
			for (i=0; i < miLista.num; i++)
			{
				write (miLista.conectados[i].socket, conectados, strlen(conectados));
			}
			
			
			printf ("%s", respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		else if (codigo== 5) //Registrarse
		{
			char nick[20];
			char passw[20];
			p = strtok(NULL, "/");
			strcpy(nick, p);
			p = strtok(NULL, "/");
			strcpy(passw, p);
			printf("Nickname: %s Contrase￱a: %s \n", nick, passw);
			
			Registrarse(nick, passw, respuesta);
			printf("3%s", respuesta);
			// Enviamos la respuesta
			write (sock_conn,respuesta , strlen(respuesta));
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
	serv_adr.sin_port = htons(9051);//puertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuerto
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	
	contador =0;
	int i;
	
	int sockets[100];
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

