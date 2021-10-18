#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char buff[512];
	char buff2[512];
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
	serv_adr.sin_port = htons(9070);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	int i;
	// Bucle infinito
	for(;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexi?n\n");
		//sock_conn es el socket que usaremos para este cliente
		
		//Variable para saber si se tiene que desconectar porque han pulsado el boton en el cliente
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
				p = strtok( NULL, "/");
				char nombre[20];
				strcpy (nombre, p);
				printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
				
				if (codigo ==1) //piden la longitd del nombre
					sprintf (buff2,"%d",strlen (nombre));
				else if (codigo == 2)
				{
					// quieren saber si el nombre es bonito
					if((nombre[0]=='M') || (nombre[0]=='S'))
						strcpy (buff2,"SI");
					else
						strcpy (buff2,"NO");
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
						strcpy(buff2,"SI");
					else
						strcpy(buff2,"NO");
					
				}
				else if (codigo == 5){
					
					//quieren el nombre en mayusculas
					int i = 0;
					while(nombre[i]!='\0'){
						nombre[i]=toupper(nombre[i]);
						i=i+1;
					}
					
					strcpy(buff2,nombre);
				}
				else
				{
					//quieren saber si son altos
					p = strtok(NULL,"/");
					float altura = atof(p);
					if (altura >= 1.70)
						strcpy(buff2,"SI");
					else
						strcpy(buff2,"NO");
				}
				
				printf ("%s\n", buff2);
				// Y lo enviamos
				write (sock_conn,buff2, strlen(buff2));
			}
		}
		// Se acabo el servicio para este cliente
		close(sock_conn);
		
	}
}
