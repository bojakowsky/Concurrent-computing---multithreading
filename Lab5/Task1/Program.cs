using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  
    class Program
    {
        //predfined:
        public static double random;
        public const int nmax = 20;        

        static public double randomReturn()
        {
            Random rand = new Random();
            random = rand.NextDouble();
            return random;
        }

        static void gnp(int n, float p,  int [,] array)
        {
            for (int i = 0 ; i < n ; i ++)
                array[i,i] = 0;
            for (int i = 0 ; i < n-1 ; i++)
                for (int j = i+1 ; j<n ; j++)
                {
                    if (randomReturn() <= p)
                        array[i,j] = array[j,i] = 1;
                    else array[i,j] = array[j,i] = 0;
                }
        }

        static void permInit(int n,  int [] p) 
        { 
            for ( int i=0; i < n ; i++ ) 
                p[ i ] = i; 
        }

        static int permNext(int n,  int [] p) {
            int i,j,x,b;

            b = 0;
            i = n-1;
            
            while (i>0) { 
                if (p[ i ]>p[ i - 1 ]) 
                { 
                    j = n-1;

                    while (p[ j ] < p[ i - 1 ]) 
                        j--;

                    x = p[ j ]; 
                    p[ j ] = p[ i - 1 ]; 
                    p[ i - 1 ] = x;
                    while ( i < n ) 
                    {
                        x=p[ i ]; 
                        p[ i ] = p[ n - 1 ]; 
                        p[ n - 1 ] = x;
                        i++; 
                        n--;
                    }
                    b=1;
                    break;
                }
            i--;
            }
        return b;
        }

        static int biggestDifference(int n, int [,] A, int [] perm) {
            int dist, best = 1;
            for (int i=0; i< n-1; i++ ) 
                for ( int j = i + 1 ; j < n ; j++ ) 
                    if ( A[i,j] == 1 ) 
                    { 
                        dist = Math.Abs( perm[i] - perm[j] ); 
                        if ( dist>best ) best = dist; 
                    }
            return best;
        }

        static void Main(string[] args)
        {
            int [] t1 = new int [nmax];
            int [,] t2 = new int [nmax, nmax];

            float p = 0.5f;
            int n = 5;
            int highest_r,width; 
            int L = 1;
            gnp( n, p ,  t2 );

            width = n-1;
    
            permInit( n ,  t1 ); 

            do {
                 highest_r = biggestDifference( n, t2, t1 );
                 if ( highest_r < width) width = highest_r;
                 Console.WriteLine("number: "+ highest_r);
                 L++;
            } while (permNext( n,  t1 ) != 0);

            Console.WriteLine("Szerokosc grafu: "+ width );
            Console.ReadLine();

            return;
        }
    }
}


        
