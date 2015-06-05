#include <iostream>
#include <ddkernel.h>

CRITICAL_SECTION CriticalSection; 
volatile int sum = 0;

typedef struct MyData {
    int val1;
} MYDATA, *PMYDATA;

DWORD WINAPI ThreadProc( LPVOID lpParameter)
{

	EnterCriticalSection(&CriticalSection); 

	PMYDATA x;
	x = (PMYDATA) lpParameter;

	sum += x->val1;

	LeaveCriticalSection(&CriticalSection);
	return 0;
}

int main( void )
{
	const int n = 16;

	HANDLE hThread[ n ];
	PMYDATA pDataArray[ n ];
    DWORD dwThreadIdArray[ n ];

	InitializeCriticalSection(&CriticalSection);
	for( int i = 0; i < n; i++ ) 
	{

		pDataArray[i] = (PMYDATA) HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY,
                sizeof(MYDATA));

		int rand = std::rand() % 100;
		std::cout << (i+1) << " :Number generated: " << rand << std::endl;
		pDataArray[i]->val1 = rand;

		hThread[i] = CreateThread( 
            NULL,                   // default security attributes
            0,                      // use default stack size  
            ThreadProc,				// thread function name
            pDataArray[i],          // argument to thread function 
            0,                      // use default creation flags 
            &dwThreadIdArray[i]
		);							// returns the thread identifier 

		if (hThread[i] == NULL) ExitProcess(3);
	}
	WaitForMultipleObjects(n, hThread, TRUE, INFINITE);
	for(int i=0; i < n; i++)
		CloseHandle(hThread[i]);

	DeleteCriticalSection(&CriticalSection);

	std::cout<< "Sum: " << sum << std::endl;
	int waiter; std::cin>>waiter;
}