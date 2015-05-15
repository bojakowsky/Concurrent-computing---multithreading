using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Task4___concurrent_method_of_GNP_graph_generation
{
    class Program
    {
        public static int n;
        static int[,] graph_array_representation;
        public static int i = 0;

        public static float p;


        public static void loop_i()
        {
            Parallel.For(0, n - 1, k =>
               {
                   loop_j();
               });

            //for (i = 0; i < n - 1; i++)
            //{
            //    Thread[] threads = new Thread[n - 1];
            //    threads[i] = new Thread(loop_j);
            //    threads[i].Start();
            //}

            //for (i = 0; i < n - 1; i++)
            //{
            //    loop_j();
            //}

        }

        public static void loop_j()
        {
            int x;
            Random random = new Random();
            for (int j = i + 1; j < n; j++)
            {
                if (random.NextDouble() <= p) x = 1;
                else x = 0;
                graph_array_representation[i, j] = x;
                graph_array_representation[j, i] = x;
            }
        }

        static void Main(string[] args)
        {
           

            Console.WriteLine("Podaj n - liczba naturalna");
            string buf = Console.ReadLine();
            n = Int32.Parse(buf);

            graph_array_representation = new int[n, n];

            Console.WriteLine("Podaj p - liczba staloprzecinkowa");
            buf = Console.ReadLine();
            p = float.Parse(buf, CultureInfo.InvariantCulture);

            var watch = Stopwatch.StartNew();

            loop_i();

            watch.Stop();

            //for ( int x = 0; x < n; x++)
            //{
            //    for (int y = 0; y < n; y++)
            //    {
            //        Console.Write(graph_array_representation[x, y]);
            //    } Console.WriteLine("\n");
            //}

            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time [ms]: " + elapsedMs.ToString());
            Console.ReadKey();
        }
    }
}
