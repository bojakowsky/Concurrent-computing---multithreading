using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;
namespace Task2___Permutation_on_N_threads
{
    static class Program
    {
        static BigInteger result = 1;

        static void permutate()
        {
            int x = Convert.ToInt32(Thread.CurrentThread.Name);
            result *= x;
            Console.WriteLine(result.ToString());
        }

        static void Main()
        {
            Console.WriteLine("Podaj n");
            int n;
            string buf = Console.ReadLine();

            try
            {
                n = Convert.ToInt32(buf);
            }

            catch (Exception)
            {
                Console.WriteLine("Zla liczba!");
                return;
            }

            Thread[] threads = new Thread[n-1];
            for (int i = 2; i <= n; i++)
            {
                threads[i - 2] = new Thread(permutate);
                threads[i - 2].Name = i.ToString();
                threads[i - 2].Start();
                threads[i - 2].Join();
            }
            Console.ReadKey();
        }
    }
}
