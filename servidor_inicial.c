#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <pthread.h>


int contador;
int i;
int sockets[100];

//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int *AtenderCliente (void *socket){
	char buff[512];
	char buff2[512];
	int ret;
	
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn = *s;
	
	int terminar = 0;
	while (terminar==0)
	{
		// Ahora recibimos su nombre, que dejamos en buff
		ret=read(sock_conn,buff, sizeof(buff));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		buff[ret]='\0';
		
		//Escribimos el nombre en la consola
		printf ("Se ha conectado: %s\n",buff);
		
		char *p = strtok( buff, "/");
		int codigo =  atoi (p);
		
		
		if (codigo == 0)
		{
			terminar = 1;
		}
		else
		{
			int numForm;
			p = strtok(NULL,"/");
			numForm = atoi(p);
			p = strtok( NULL, "/");
			char nombre[20];
			strcpy (nombre, p);
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
			
			
			if (codigo ==1) //piden la longitd del nombre
				sprintf (buff2,"1/%d/%d",numForm,strlen (nombre));
			else if (codigo == 2)
			{
				// quieren saber si el nombre es bonito
				if((nombre[0]=='M') || (nombre[0]=='S'))
					sprintf (buff2,"2/%d/SI",numForm);
				else
					sprintf (buff2,"2/%d/NO",numForm);
			}
			else if (codigo==4) //Nombre palindromo
			{
				//para tener todo en minusculas para hacer la comprobacion
				int i = 0;
				while(nombre[i]!='\0'){
					nombre[i]=tolower(nombre[i]);
					i=i+1;
				}
				
				int p_inicial = 0;
				int p_final = strlen(nombre)-1;
				int diferencia = 0;
				while (p_inicial<p_final && diferencia==0){
					
					if (nombre[p_inicial]==nombre[p_final]){
						p_inicial=p_inicial+1;
						p_final = p_final-1;
					}
					else
						diferencia=1;
					
				}
				if(diferencia==0)
					   sprintf(buff2,"4/%d/SI",numForm);
				else
					sprintf(buff2,"4/%d/NO",numForm);
				
			}
			else if (codigo == 5){
				
				//quieren el nombre en mayusculas
				int i = 0;
				while(nombre[i]!='\0'){
					nombre[i]=toupper(nombre[i]);
					i=i+1;
				}
				
				sprintf(buff2,"5/%d/%s",numForm,nombre);
			}
			else
			{
				//quieren saber si son altos
				p = strtok(NULL,"/");
				float altura = atof(p);
				if (altura >= 1.70)
					sprintf(buff2,"3/%d/SI",numForm);
				else
					sprintf(buff2,"3/%d/NO",numForm);
			}
		}
		
		if (codigo!=0){
			printf ("%s\n", buff2);
			// Y lo enviamos
			write (sock_conn,buff2, strlen(buff2));
		}

		if (codigo!=0 && codigo!=6){
			pthread_mutex_lock(&mutex); //No me interrumpas
			contador=contador+1;
			pthread_mutex_unlock(&mutex); //Ya puedes interrumpirme
			
			//Notificar a todos los clientes conectados
			char notificacion[20];
			sprintf(notificacion,"6/%d",contador);
			int j;
			for(j=0;j<i;j++){
				write(sockets[j],notificacion,strlen(notificacion));
			}
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn);
	pthread_exit(0);
	
}

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9050);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	contador = 0;
	pthread_t thread[100];
	pthread_mutex_init(&mutex,NULL);
	
	// Bucle infinito
	for(i=0;i<10;i++){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexi?n\n");
		
		sockets[i] = sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		//Crear thread y decirle lo que tiene que hacer

		pthread_create (&thread[i], NULL, AtenderCliente, &sockets[i]);
	}
	pthread_mutex_destroy(&mutex);
}
