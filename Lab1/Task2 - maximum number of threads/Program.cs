using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task2___maximum_number_of_threads
{
    class Program
    {
        static void emptyMethod()
        {
            Console.WriteLine("Thread created!");
            Thread.Sleep(1000000);
        }

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[2000];
            for (int i = 0; i < 2000; i++)
            {
                try
                {
                    threads[i] = new Thread(emptyMethod);
                    threads[i].Start();
                }
                catch (Exception)
                {
                    Console.WriteLine("Error on creating a " + i.ToString() + " thread!");
                    Console.ReadKey();
                    return;
                }
            }

            Console.ReadKey();
        }
    }
}
