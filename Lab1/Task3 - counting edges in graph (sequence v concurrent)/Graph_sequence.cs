﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3___counting_edges_in_graph__sequence_v_concurrent_
{
    class Graph_sequence
    {
        readonly int number_of_graph_vertex;
        private int [,] graph_array_representation;
        private int result;

        private Graph_sequence() { }
        public Graph_sequence(int size)
        {
            number_of_graph_vertex = size;
            graph_array_representation = new int[number_of_graph_vertex, number_of_graph_vertex];
            createRandomGraph();
        }

        private void createRandomGraph()
        {
            Random random = new Random();

            for (int i = 0; i < number_of_graph_vertex; i++)
            {
                for (int j = 0 ; j < number_of_graph_vertex ; j++)
                {
                    if (i != j)
                    {
                        graph_array_representation[i, j] = random.Next(0, 2);
                        graph_array_representation[j, i] = graph_array_representation[i, j];
                    }
                    else
                    {
                        graph_array_representation[i, j] = 0;
                    }
                }
            }
        }

        public void printOutGraph()
        {
            for (int i = 0; i < number_of_graph_vertex; i++)
            {
                for (int j = 0; j < number_of_graph_vertex; j++)
                {
                    Console.Write(graph_array_representation[i, j] + "   ");
                } Console.WriteLine("\n");
            }
        }

        public int countEdges()
        {
            for (int i = 0; i < number_of_graph_vertex - 1; i++)
            {
                for (int j = i + 1; j < number_of_graph_vertex; j++)
                {
                    result += graph_array_representation[i, j];
                }
            }
            return result;
        }

        public void printEdges()
        {
            Console.WriteLine("Edges: " + countEdges())
                ;
        }

        
    }
}
