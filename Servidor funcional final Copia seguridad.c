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

char consulta [200];

int contador;

int PonConectado (ListaConectados *lista, char nombre[20], int socket){
	/*A￯﾿ﾱade nuevp conectados. retorna 0 si ok y -1 si la 
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
	//devuelve la posicion en la lista o -1 si no est￯﾿ﾡ ne la lista
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

int Elimina (ListaConectados *lista, int socket)
	//retorna 0 si elimina y -1 si ese usuario no est￯﾿ﾡ en la lista
{
	int pos = DamePosicion (lista, socket);//no lleva a mbersand ya que ya he recibido la lista por referencia, *lista del main ya es un puntero
	if (pos==-1)
		return -1;
	else{
		int i;
		for  (i=pos; i< lista->num-1; i++)
			lista->conectados[i] = lista->conectados[i+1];
		
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

int id = 0;

int Registrarse (char nick[20], char passw[20], char respuesta[20])
{
	printf("e entrao a registrar\n");
	

	char consulta [512];
	
	sprintf(consulta, "SELECT jugadores.Nickname FROM jugadores WHERE jugadores.Nickname = '%s'", nick);
	err = mysql_query (conn, consulta);
	printf("el nombre y contrase￱a son: %s, %s\n" ,nick, passw);
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
		printf ("%s \n", consulta);
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
		printf("el nombre y contrase￱a son: %s, %s\n" ,nick, passw);
		if (err != 0)
			{
				printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
		sprintf(respuesta, "5/0");
	}
	else
	{
		sprintf(respuesta, "5/-1");
	}
}

int EliminarBD (char nick[20],char consulta[200], char respuesta [200])
{
	sprintf(consulta, "DELETE FROM jugadores WHERE jugadores.Nickname = '%s' ", nick);
	printf("consulta: %s\n",consulta);
	err = mysql_query (conn, consulta);
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	else
	{
		sprintf(respuesta, "6/");
	}
}

int DameSocket (ListaConectados *lista, char nombre[20]){
	//Devueleve el socket
	int i=0;
	int encontrado = 0;
	while ((i< lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados[i].socket;
	else
		return 0;
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
		printf ("El codigo es: %d\n",codigo);
		
		if (codigo ==0)
		{
			char conectados [300];
			printf("el socket borrado es: %d\n", sock_conn);
			int elim = Elimina (&miLista, sock_conn);
			
			DameConectados(&miLista, conectados);
			printf("Lista nueva: %s\n", conectados);
			for (i=0; i < miLista.num; i++)
			{
				write (miLista.conectados[i].socket, conectados, strlen(conectados));
			}
			if (elim == 0)
			{
				printf("Eliminado correctamente\n"); 
			}
			else
			{
				printf("No eliminado\n"); 
			}
			terminar=1;
			printf ("termino\n");
		}
		
		
		
		else if (codigo==1) //log in
		{
			char nick[20];
			p = strtok( NULL, "/");
			strcpy(nick, p);
			char passw[20];
			p = strtok(NULL, "/");
			strcpy(passw, p);
			char consulta[100];
			printf ("hola buenas\n");
			
			sprintf(consulta, "SELECT jugadores.Nickname FROM jugadores WHERE jugadores.Nickname = '%s' AND jugadores.Password = '%s'", nick, passw);
			
			err=mysql_query (conn, consulta);
			if (err!=0) 
			{
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				exit (1);
				write (sock_conn,respuesta, strlen(respuesta));
			}
			
			
			printf("consulta: %s\n",consulta);
			
			err= mysql_query (conn, consulta);
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			
			if (row == NULL)
			{
				sprintf(respuesta, "1/NO");
			}
			else
			{
				int res = PonConectado(&miLista, nick, sock_conn);
				if (res == 0)
				{ 
					printf("%s ha sido a￯﾿ﾱadido a la lista de usuarios\n", nick); 
				}
				
				strcpy(respuesta, "1/SI");
				printf ("Respuesta: %s\n", respuesta);
				char conectados [300];
				DameConectados (&miLista, conectados);
				printf("lista de conectados: %s\n", conectados);
				for (i=0; i < miLista.num; i++)
				{
					write (miLista.conectados[i].socket, conectados, strlen(conectados));
				}
			}
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		else if (codigo ==2) //PRIMERA CONSULTA
		{
			char fecha[30];
			p = strtok(NULL, "/"); 
			strcpy(fecha,p);
			char consulta[500];
			char nombres[50];
			
			sprintf (consulta, "SELECT jugadores.Nickname FROM jugadores,partidas,datos WHERE partidas.Fecha = '%s' AND partidas.id=datos.idP AND (datos.idJ1 = jugadores.id OR datos.idJ2 = jugadores.id)",fecha);
			printf("consulta: %s\n",consulta);
			err= mysql_query (conn, consulta);
		
			if (err!=0)
			{
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
				char respuesta1 [200];
				while (row!=NULL) 
				{
					
					sprintf (nombres, row[0]);
					
					row = mysql_fetch_row(resultado);
					
					
					sprintf(respuesta1, "%s%s/ \n", resultado, nombres);
					
				}
				sprintf (respuesta, "2/%s",respuesta1);
			}	
			printf ("la respuesta es %s\n", respuesta);
			write (sock_conn,respuesta, strlen(respuesta));	
/*			char fecha[30];*/
/*			p = strtok(NULL, "/"); */
/*			strcpy(fecha,p);*/
			
/*			char consulta[500];*/
/*			char nombres[50];*/
			
/*			sprintf (consulta, "SELECT jugadores.Nickname FROM jugadores,partidas,datos WHERE partidas.Fecha = '%s' AND partidas.id=datos.idP AND (datos.idJ1 = jugadores.id OR datos.idJ2 = jugadores.id)",fecha);*/
/*			err= mysql_query (conn, consulta);*/
			
/*			if (err!=0) */
/*			{*/
/*				printf ("Error al consultar datos de la base %u %s\n",*/
/*						mysql_errno(conn), mysql_error(conn));*/
/*				exit (1);*/
/*			}*/
			
/*			printf("consulta: '%s'\n",consulta);*/
			
/*			resultado = mysql_store_result (conn);*/
/*			row = mysql_fetch_row (resultado);*/
			
/*			if (row == NULL)*/
/*				sprintf (resultado, "2/NO");*/
			
/*			else */
/*			{*/
/*				while (row!=NULL) */
/*				{*/
/*					sprintf (nombres, row[0]);*/
/*					row = mysql_fetch_row(resultado);*/
/*					sprintf(resultado, "%s%s/\n", resultado, nombres);*/
/*				}*/
/*			}	*/
/*			printf("respuesta: %s\n",resultado);*/
/*			write (sock_conn,resultado, strlen(resultado));*/
		}
		
		else if (codigo==3)//SEGUNDA CONSULTA
		{
			char nombre[30];
			p = strtok(NULL, "/"); 
			strcpy(nombre,p);
			
			char prueba[70];
			
			char consulta[500];
			printf("el nick seleccionado es: '%s'\n", nombre);
			
			sprintf (consulta, "SELECT SUM(partidas.Duracion) FROM (partidas) WHERE partidas.Ganador = '%s'",nombre);
			printf("consulta: %s\n",consulta);
			err= mysql_query (conn, consulta);
			
			if (err!=0) 
			{
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			char suma [50];
			
			if (row[0] == NULL || row[1]==NULL)
			{
				sprintf (respuesta, "3/NO");
			}
			else
			{
				sprintf (suma, row[0]);
				printf("%s\n",suma); 
				sprintf (respuesta, "3/%s", suma);
				printf("respuesta: %s\n",respuesta);
			}	
			write (sock_conn,respuesta, strlen(respuesta));
		}


		else if (codigo== 5) //Registrarse Base Datos
		{
			char nick[20];
			char passw[20];
			p = strtok(NULL, "/");
			strcpy(nick, p);
			p = strtok(NULL, "/");
			strcpy(passw, p);
			printf("Nickname: %s Contrase￱a: %s \n", nick, passw);

			Registrarse(nick, passw, respuesta);
			// Enviamos la respuesta
			write (sock_conn,respuesta , strlen(respuesta));
		}
		
		else if (codigo == 6) //Eliminar Base Datos
		{
			p = strtok(NULL,"/");
			char nick[20];
			strcpy(nick,p);

			char consulta[500];
			
			EliminarBD(nick, consulta, respuesta);
			printf("nombre dado de baja: %s\n",nick);
			
			write(sock_conn,respuesta,strlen(respuesta));
			
		}
		
		else if (codigo == 7) //Invitar
		{
			printf("hola\n");
			char notificacion[100];
			p = strtok(NULL,"/");
			int numero =  atoi (p);
			printf("el numero de personas es: %d\n",numero);
			//dependiendo del numero de personas invitadas se mandan diferentes mns al servidor
			if (numero == 1) 
			{ 
				printf("1 persona invitada\n");
				char nick1[20];
				char host[20];
				p = strtok(NULL, "/");
				strcpy(host, p);
				p = strtok(NULL, "/");
				strcpy(nick1, p);
				
				//pide socket
				int socketnick1 = DameSocket(&miLista, nick1);
				printf("el Socket de %s es %d\n", nick1, socketnick1);
				
				//envia mensaje y notificacion de invitacion
				if (socketnick1!=0)
				{	
					sprintf(respuesta, "7/0");	
					sprintf(notificacion, "8/%d/%s/%s" ,numero,host,nick1);
					printf("el mensaje enviado es: %s\n", notificacion);
					write (socketnick1, notificacion, strlen(notificacion));
					
					int sockethost = DameSocket(&miLista, host);
					printf("el Socket de %s es %d\n", host, sockethost);
					sprintf(notificacion, "12/%d/%s/%s",numero,host,nick1);
					printf("el mensaje enviado es: %s\n", notificacion);
					write (sockethost, notificacion, strlen(notificacion));
				}
				else
				{
					sprintf(respuesta, "7/-1");	
					printf("el mensaje enviado es: %s", respuesta);
				}
				write(sock_conn,respuesta,strlen(respuesta));
			}
			else if (numero == 2)
			{
				printf("2 personas invitadas\n");
				char nick1[20];
				char host[20];
				char nick2[20];
				p = strtok(NULL, "/");
				strcpy(host, p);
				p = strtok(NULL, "/");
				strcpy(nick1, p);
				p = strtok(NULL, "/");
				strcpy(nick2, p);

				
				int socketnick1 = DameSocket(&miLista, nick1);
				printf("el Socket de %s es %d\n", nick1, socketnick1);
				int socketnick2 = DameSocket(&miLista, nick2);
				printf("el Socket de %s es %d\n", nick2, socketnick2);
				
			
				if (socketnick1!=0 || socketnick2!=0)
				{	
					sprintf(respuesta, "7/0");	
					sprintf(notificacion, "8/%d/%s/%s/%s",numero,host, nick1, nick2);
					printf("el mensaje enviado es: %s\n", notificacion);
					write (socketnick1, notificacion, strlen(notificacion));
					write (socketnick2, notificacion, strlen(notificacion));
					
					int sockethost = DameSocket(&miLista, host);
					printf("el Socket de %s es %d\n", host, sockethost);
					sprintf(notificacion, "12/%d/%s/%s/%s",numero,host,nick1,nick2);
					printf("el mensaje enviado es: %s\n", notificacion);
					write (sockethost, notificacion, strlen(notificacion));
				}
				else
				{
					sprintf(respuesta, "7/-1");	
					printf("el mensaje enviado es: %s", respuesta);
				}
				write(sock_conn,respuesta,strlen(respuesta));
			}
			else if (numero == 3)
			{
				printf("3 personas invitadas\n");
				char nick1[20];
				char host[20];
				char nick2[20];
				char nick3[20];
				p = strtok(NULL, "/");
				strcpy(host, p);
				p = strtok(NULL, "/");
				strcpy(nick1, p);
				p = strtok(NULL, "/");
				strcpy(nick2, p);
				p = strtok(NULL, "/");
				strcpy(nick3, p);
				
				
				int socketnick1 = DameSocket(&miLista, nick1);
				printf("el Socket de %s es %d\n", nick1, socketnick1);
				int socketnick2 = DameSocket(&miLista, nick2);
				printf("el Socket de %s es %d\n", nick2, socketnick2);
				int socketnick3 = DameSocket(&miLista, nick3);
				printf("el Socket de %s es %d\n", nick3, socketnick3);
				
				if (socketnick1!=0 || socketnick2!=0 || socketnick3!=0)
				{	
					sprintf(respuesta, "7/0");	
					sprintf(notificacion, "8/%d/%s/%s/%s/%s",numero,host, nick1, nick2,nick3);
					printf("el mensaje enviado es: %s\n", notificacion);
					write (socketnick1, notificacion, strlen(notificacion));
					write (socketnick2, notificacion, strlen(notificacion));
					write (socketnick3, notificacion, strlen(notificacion));
					
					int sockethost = DameSocket(&miLista, host);
					printf("el Socket de %s es %d\n", host, sockethost);
					sprintf(notificacion, "12/%d/%s/%s/%s/%s",numero,host,nick1,nick2,nick3);
					printf("el mensaje enviado es: %s\n", notificacion);
					write (sockethost, notificacion, strlen(notificacion));
					
				}
				else
				{
					sprintf(respuesta, "7/-1");	
					printf("el mensaje enviado es: %s", respuesta);
				}
				write(sock_conn,respuesta,strlen(respuesta));
			}
			else
			{
				printf("error en el contador");
			}
			printf("llegue al final");
		}
		else if (codigo == 8) //Invitar Aceptar o No
		{
			char notificacion[100];
			char invitar[20];
			char host[20];
			p = strtok(NULL,"/");
			strcpy(invitar,p);
			p = strtok(NULL, "/");
			strcpy(host, p);
			printf("El mensaje recibido es %s\n", invitar);
			int sockethost = DameSocket(&miLista, host);
			printf("el Socket de %s es %d\n", host, sockethost);
			if (strcmp(invitar,"SI") == 0)	
			{
				if (sockethost!=0) 
				{	
					printf("hola\n");
					sprintf(notificacion, "9/0");
					write (sockethost, notificacion, strlen(notificacion));
				}
			}
			else if (strcmp(invitar,"NO") == 0)
			{
				printf("adios\n");
				sprintf(notificacion, "9/-1");
				write (sockethost, notificacion, strlen(notificacion));
			}
		}
		else if (codigo == 10) //Chat enviar mensaje
		{
			char notificacion[100];
			p = strtok(NULL,"/");
			int numero =  atoi (p);
			printf("el numero de personas es: %d\n",numero);
			
			if (numero == 1) 
			{
				char persona1[20];
				char mnsChat[200];
				char hostmns[20];
				p = strtok(NULL,"/");
				strcpy(persona1,p);
				p = strtok(NULL, "/");
				strcpy(mnsChat, p);
				p = strtok(NULL, "/");
				strcpy(hostmns, p);
				printf("El mensaje recibido es %s\n", mnsChat);
				int socketenviar1 = DameSocket(&miLista, persona1);
				printf("el Socket de %s es %d\n", persona1, socketenviar1);
				printf("el host del mensaje es: %s\n",hostmns);
				
				sprintf(respuesta, "10/%s/%s" ,mnsChat, hostmns);
				printf("el mensaje enviado es: %s\n", respuesta);
				write (socketenviar1, respuesta, strlen(respuesta));
			}
			if (numero == 2) 
			{
				char persona1[20];
				char persona2[20];
				char mnsChat[200];
				char hostmns[20];
				p = strtok(NULL,"/");
				strcpy(persona1,p);
				p = strtok(NULL,"/");
				strcpy(persona2,p);
				p = strtok(NULL, "/");
				strcpy(mnsChat, p);
				p = strtok(NULL, "/");
				strcpy(hostmns, p);
				printf("El mensaje recibido es %s\n", mnsChat);
				int socketenviar1 = DameSocket(&miLista, persona1);
				printf("el Socket de %s es %d\n", persona1, socketenviar1);
				int socketenviar2 = DameSocket(&miLista, persona2);
				printf("el Socket de %s es %d\n", persona2, socketenviar2);
				printf("el host del mensaje es: %s\n",hostmns);
				
				sprintf(respuesta, "10/%s/%s" ,mnsChat,hostmns);
				printf("el mensaje enviado es: %s\n", respuesta);
				write (socketenviar1, respuesta, strlen(respuesta));
				write (socketenviar2, respuesta, strlen(respuesta));
			}
			if (numero == 3) 
			{
				char persona1[20];
				char persona2[20];
				char persona3[20];
				char mnsChat[200];
				char hostmns[20];
				p = strtok(NULL,"/");
				strcpy(persona1,p);
				p = strtok(NULL,"/");
				strcpy(persona2,p);
				p = strtok(NULL,"/");
				strcpy(persona3,p);
				p = strtok(NULL, "/");
				strcpy(mnsChat, p);
				p = strtok(NULL, "/");
				strcpy(hostmns, p);
				
				printf("El mensaje recibido es %s\n", mnsChat);
				int socketenviar1 = DameSocket(&miLista, persona1);
				printf("el Socket de %s es %d\n", persona1, socketenviar1);
				int socketenviar2 = DameSocket(&miLista, persona2);
				printf("el Socket de %s es %d\n", persona2, socketenviar2);
				int socketenviar3 = DameSocket(&miLista, persona3);
				printf("el Socket de %s es %d\n", persona2, socketenviar3);
				printf("el host del mensaje es: %s\n",hostmns);
				
				sprintf(respuesta, "10/%s/%s" ,mnsChat,hostmns);
				printf("el mensaje enviado es: %s\n", respuesta);
				write (socketenviar1, respuesta, strlen(respuesta));
				write (socketenviar2, respuesta, strlen(respuesta));
				write (socketenviar3, respuesta, strlen(respuesta));
			}
		}
		else if (codigo == 11) //Desconectar chat
		{
			char notificacion[100];
			p = strtok(NULL,"/");
			int numero =  atoi (p);
			printf("el numero de personas es: %d\n",numero);
			
			if (numero == 1) 
			{
				char persona1[20];
				char desconect[20];
				p = strtok(NULL,"/");
				strcpy(persona1,p);
				p = strtok(NULL, "/");
				strcpy(desconect, p);
				
				int socketenviar1 = DameSocket(&miLista, persona1);
				printf("el Socket de %s es %d\n", persona1, socketenviar1);
				printf("persona que se queire desconectar: %s\n",desconect);
				
				sprintf(respuesta, "11/%s",desconect);
				printf("el mensaje enviado es: %s\n", respuesta);
				write (socketenviar1, respuesta, strlen(respuesta));
			}
			if (numero == 2) 
			{
				char persona1[20];
				char persona2[20];
				char desconect[20];
				p = strtok(NULL,"/");
				strcpy(persona1,p);
				p = strtok(NULL,"/");
				strcpy(persona2,p);
				p = strtok(NULL, "/");
				strcpy(desconect, p);

				int socketenviar1 = DameSocket(&miLista, persona1);
				printf("el Socket de %s es %d\n", persona1, socketenviar1);
				int socketenviar2 = DameSocket(&miLista, persona2);
				printf("el Socket de %s es %d\n", persona2, socketenviar2);
				printf("la persona que se ha desconectado: %s\n",desconect);
				
				sprintf(respuesta, "11/%s",desconect);
				printf("el mensaje enviado es: %s\n", respuesta);
				write (socketenviar1, respuesta, strlen(respuesta));
				write (socketenviar2, respuesta, strlen(respuesta));
			}
			if (numero == 3) 
			{
				char persona1[20];
				char persona2[20];
				char persona3[20];
				char desconect[20];
				p = strtok(NULL,"/");
				strcpy(persona1,p);
				p = strtok(NULL,"/");
				strcpy(persona2,p);
				p = strtok(NULL,"/");
				strcpy(persona3,p);
				p = strtok(NULL, "/");
				strcpy(desconect, p);
				
				int socketenviar1 = DameSocket(&miLista, persona1);
				printf("el Socket de %s es %d\n", persona1, socketenviar1);
				int socketenviar2 = DameSocket(&miLista, persona2);
				printf("el Socket de %s es %d\n", persona2, socketenviar2);
				int socketenviar3 = DameSocket(&miLista, persona3);
				printf("el Socket de %s es %d\n", persona2, socketenviar3);
				printf("persona que se ha desconectado: %s\n",desconect);
				
				sprintf(respuesta, "11/%s",desconect);
				printf("el mensaje enviado es: %s\n", respuesta);
				write (socketenviar1, respuesta, strlen(respuesta));
				write (socketenviar2, respuesta, strlen(respuesta));
				write (socketenviar3, respuesta, strlen(respuesta));
			}
		}

/*	if ((codigo==0)||(codigo==1)||(codigo==2))*/
/*	{*/
/*		pthread_mutex_lock (&mutex);*///no interrumpas ahora
/*		contador=contador+1;*/
/*		pthread_mutex_unlock ( &mutex); *///puedes interrumpir
/*	}*/
	// Se acabo el servicio para este cliente
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
	serv_adr.sin_port = htons(9071);//puertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuertopuerto
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
		
		pthread_create (&thread, NULL, AtenderCliente, &sockets[i]);
		i=i+1;
	}
}