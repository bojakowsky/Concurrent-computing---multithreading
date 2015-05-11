#include <pthread.h> 
#include <stdlib.h> 
#include <stdio.h>
#include <iostream>

void *Hello(void *arg)
{
	for (int i = 0 ; i < 10 ; i ++ )
		printf("Hello! \n");
	return NULL;
}

void First_Example()
{
	pthread_t myThread;
	if ( pthread_create( &myThread, NULL, Hello , NULL) )
	{
		printf("Error while creating a thread\n"); 
		abort(); 
	}
	if ( pthread_join ( myThread, NULL ) ) { 
		printf("Error while closing a thread\n");
		exit(0); 
	}
	exit(0);
}


void incrementVariable(int& variable, int incrementStep)
{
	for (int i = 0 ; i < 20 ; i++)
	{
		variable += incrementStep;
		std::cout<< variable << std::endl;
	}
}

void multiplyVariable(int &variable)
{
	for (int i = 0 ; i < 10; i++)
	{
		variable *= 2;
		std::cout<< variable << std::endl;
	}
}

struct variableStruct
{
	int variable;
	int incrementStep;

	variableStruct(int var, int step)
	{
		variable = var;
		incrementStep = step;
	}
};

void *TheFirstThreadFromSecondExample(void *arg)
{
	variableStruct *myStruct = ( variableStruct* ) arg;
	incrementVariable(myStruct->variable, 1);
	return NULL;
}

void *TheSecondThreadFromSecondExample(void *arg)
{
	variableStruct *myStruct = ( variableStruct* ) arg;
	multiplyVariable(myStruct->variable);
	return NULL;
}

void Second_Example()
{
	pthread_t firstThread;
	pthread_t secondThread;

	variableStruct* variableToInc = new variableStruct(0, 5);
	if ( pthread_create( &firstThread, NULL, TheFirstThreadFromSecondExample , (void*)(variableToInc) ))
	{
		printf("Error while creating a thread\n"); 
		abort(); 
	}

	if ( pthread_create( &secondThread, NULL, TheSecondThreadFromSecondExample , (void*)(variableToInc) ))
	{
		printf("Error while creating a thread\n"); 
		abort(); 
	}

	if ( pthread_join ( firstThread, NULL ) ) { 
		printf("Error while closing a thread\n");
		exit(0); 
	}

	if ( pthread_join ( secondThread, NULL ) ) { 
		printf("Error while closing a thread\n");
		exit(0); 
	}

	char wait;
	std::cin >> wait;
}

pthread_mutex_t mutex;
void *TheFirstThreadFromThirdExample(void *arg)
{
	pthread_mutex_lock(&mutex);
	variableStruct *myStruct = ( variableStruct* ) arg;
	incrementVariable(myStruct->variable, 1);
	pthread_mutex_unlock(&mutex);
	return NULL;
}

void *TheSecondThreadFromThirdExample(void *arg)
{
	pthread_mutex_lock(&mutex);
	variableStruct *myStruct = ( variableStruct* ) arg;
	multiplyVariable(myStruct->variable);
	pthread_mutex_unlock(&mutex);
	return NULL;
}

void Third_Example()
{
	pthread_t firstThread;
	pthread_t secondThread;

	variableStruct* variableToInc = new variableStruct(0, 5);

	 pthread_mutex_init(&mutex, NULL);

	if ( pthread_create( &firstThread, NULL, TheFirstThreadFromThirdExample , (void*)(variableToInc) ))
	{
		printf("Error while creating a thread\n"); 
		abort(); 
	}

	if ( pthread_create( &secondThread, NULL, TheSecondThreadFromThirdExample , (void*)(variableToInc) ))
	{
		printf("Error while creating a thread\n"); 
		abort(); 
	}

	if ( pthread_join ( firstThread, NULL ) ) { 
		printf("Error while closing a thread\n");
		exit(0); 
	}

	if ( pthread_join ( secondThread, NULL ) ) { 
		printf("Error while closing a thread\n");
		exit(0); 
	}

	pthread_mutex_destroy(&mutex);

	char wait;
	std::cin >> wait;
}

int main(void) {
	//First_Example();
	//Second_Example();
	Third_Example();
} 