using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task4___Multithreaded_Game_of_Life
{
    class Program
    {
        static void generateMap()
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    array[i, j] = rand.NextDouble() >= 0.5;
        }

        static void printOutArray()
        {
            while (true)
            {
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        Console.Write(Convert.ToInt16(array[i, j]));
                    Console.WriteLine();
                }
                Thread.Sleep(5000);
            }
            
        }

        static int returnNumberOfNeighbours(int x, int y)
        {
            int howMany = 0;
            
            for (int i = x - 1; i < x + 1; i++)
            {
                for (int j = y - 1; j < y + 1; j++)
                {
                    if (i == -1 || j == -1) continue;
                    else if (i == x && j == y) continue;
                    if (array[i%n, j%n] == true)
                        howMany++;
                }
            }
            return howMany;
        }
        static void liveOrDie(object obj_x, object obj_y)
        {
            int x = (int)obj_x;
            int y = (int)obj_y;

                int neighbours = returnNumberOfNeighbours(x, y);
                if (array[x, y] == false && neighbours == 3)
                    next_array[x, y] = true;
                else if (array[x, y] == true && (neighbours == 2 || neighbours == 3))
                { next_array[x, y] = true; }
                else next_array[x, y] = false;
        }

        static int n = 10;
        static bool[,] array = new bool[n, n];
        static bool[,] next_array = new bool[n, n];

        static void copy(bool[,] a, bool[,] n_a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = n_a[i, j];
                }
            }
        }

        static void Main(string[] args)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = false;
                }
            }
            generateMap();

            Thread timer = new Thread(printOutArray);
            timer.Start();

            Thread[,] threads = new Thread[n, n];
            while(true)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        threads[i, j] = new Thread(() => liveOrDie(i,j));
                        threads[i, j].Start();
                        Thread.Sleep(50);
                    }
                }
                Thread.Sleep(1000);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        threads[i, j].Join();
                    }
                }
                Thread.Sleep(1000);
                copy(array, next_array);
            }
        }
    }
}
