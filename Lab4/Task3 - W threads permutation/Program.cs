using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task3___W_threads_permutation
{
    class Program
    {

        static List<int> copyListsWithoutReference(List<int> list1)
        {
            List<int> list_buf = new List<int>();
            foreach (var e in list1)
            {
                list_buf.Add(e);
            }
            return list_buf;
        }

        static List<int> copyTakensWithoutReference(List<int> taken)
        {
            List<int> taken_buf = new List<int>();
            foreach (var e in taken)
            {
                taken_buf.Add(e);
            }
            return taken_buf;
        }

        static bool isAvailable(List<int> taken, int x)
        {
            int found = taken.FindIndex(i => i == x);
            if (found == -1)
                return true;
            else return false;
        }

        static void printPermutations(object obj, object data, object notAvailable)
        {
            int number_of_threads = (int)obj;       
            if (number_of_threads == 0)
            {
                List<int> lx = (List<int>)data;
                foreach (var l in lx)
                {
                    Console.Write(l.ToString() + " ");
                }
                Console.WriteLine();
                return;
            }
            Thread[] threads = new Thread[length];
            List<int> list = (List<int>)data;
            List<int> taken = (List<int>)notAvailable;

            for (int j = 0; j < length; j++)
            {
               
                if (isAvailable(taken, j + 1))
                {
                    list.Add(j + 1);
                    taken.Add(j + 1);
                    List<int>  list_buf = copyListsWithoutReference(list);
                    List<int>  taken_buf = copyTakensWithoutReference(taken);
                    threads[j] = new Thread(() => printPermutations((number_of_threads-1), list_buf , taken_buf));
                    threads[j].Name = j.ToString() + " DEBUG LOG";
                    list.Remove(j + 1);
                    taken.Remove(j + 1);
                    //threads[j].Name = (thread_number+j).ToString();
                    //threads[j].Start((number_of_threads-1));
                    threads[j].Start();             
                    threads[j].Join();
                }
            }
        }

        static int length;
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj n");
            
            string buf = Console.ReadLine();
            int n;
            try
            {
                n = Convert.ToInt32(buf);
                length = n;
            }

            catch (Exception)
            {
                Console.WriteLine("Zla liczba!");
                return;
            }
            List<int> data = new List<int>();
            List<int> taken = new List<int>();
            Thread thread = new Thread(() => printPermutations(n,  data, taken));
            thread.Name = "DEBUG LOG - 0";
            thread.Start();
            thread.Join();

            Console.ReadKey();
        }
    }
}
