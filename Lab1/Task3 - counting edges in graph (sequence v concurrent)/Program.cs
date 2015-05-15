using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
namespace Task_3___counting_edges_in_graph__sequence_v_concurrent_
{
    class Program
    {
        static void graphSequence()
        {
            Graph_sequence graph = new Graph_sequence(1000);
            //graph.printOutGraph();

            var watch = Stopwatch.StartNew();
            graph.countEdges();
            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time [ms]: " + elapsedMs.ToString());

            //graph.printEdges();
        }

        static void graphConcurrent()
        {
            const int size = 1000;
            Graph_concurrent graph = new Graph_concurrent(size);
            //graph.printOutGraph();

            var watch = Stopwatch.StartNew();
            Thread[] threads = new Thread[size];
            
            
            for (int i = 0; i < size - 1; i++)
            {
                threads[i] = new Thread(graph.countEdges);
                threads[i].Name = i.ToString();
                threads[i].Start();
                threads[i].Join();
            }


            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time [ms]: " + elapsedMs.ToString());

            //graph.printEdges();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Sequence version: ");
            graphSequence();

            Console.WriteLine("\nConcurrent version: ");
            graphConcurrent();
            Console.ReadKey();
        }
    }
}
