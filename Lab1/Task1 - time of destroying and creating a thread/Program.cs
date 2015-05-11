using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace CreatingAndDestroyingThreads
{

    
    class Program
    {

        static public void EmptyMethodForCreating() 
        {
            //Thread.Sleep(100);
        }

        static public void EmptyMethodForAborting()
        {
            //Thread.Sleep(100);
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                creatingThread();
                AbortingThread();
                Console.WriteLine("-------");
            }
            Console.ReadKey();
        }

        static public void creatingThread()
        {
            var watch = Stopwatch.StartNew();

            Thread new_thread = new Thread(EmptyMethodForCreating);
            new_thread.Start();
            new_thread.Join();

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time [ms]: " + elapsedMs.ToString());
        }

        static public void AbortingThread()
        {

            Thread new_thread = new Thread(EmptyMethodForAborting);
            new_thread.Start();

            var watch = Stopwatch.StartNew();

            new_thread.Abort();

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time [ms]: " + elapsedMs.ToString());

        }
    }
}
