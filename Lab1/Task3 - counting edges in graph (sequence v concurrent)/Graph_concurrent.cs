using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task_3___counting_edges_in_graph__sequence_v_concurrent_
{
    class Graph_concurrent
    {
        readonly int number_of_graph_vertex;
        int [,] graph_array_representation;
        private int[] result;

        private Graph_concurrent() { }
        public Graph_concurrent(int size)
        {
            number_of_graph_vertex = size;
            graph_array_representation = new int[number_of_graph_vertex, number_of_graph_vertex];
            result = new int[size];
            for (int i = 0; i < size; i++)
                result[i] = 0;
            createRandomGraph();
        }

        private void createRandomGraph()
        {
            Random random = new Random();

            for (int i = 0; i < number_of_graph_vertex; i++)
            {
                for (int j = 0 ; j < number_of_graph_vertex ; j++)
                {
                    graph_array_representation[i, j] = random.Next(0, 2);
                    graph_array_representation[j, i] = graph_array_representation[i, j];
                }
            }
        }

        public void printOutGraph()
        {
            for (int i = 0; i < number_of_graph_vertex; i++)
            {
                for (int j = 0; j < number_of_graph_vertex; j++)
                {
                    Console.Write(graph_array_representation[i, j] + " ");
                } Console.WriteLine();
            }
        }

        public void countEdges()
        {
            for (int i = 0; i < number_of_graph_vertex; i++)
            {
                result[i] += graph_array_representation[int.Parse(Thread.CurrentThread.Name), i];
            }

        }

        public void printEdgesForEachVertex()
        {
            for (int i = 0; i < number_of_graph_vertex; i++)
            {

                Console.WriteLine("Vertex " + (i+1) + ", edges: " + result[i]);
            }
        }
    }
}
