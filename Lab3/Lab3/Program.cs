using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab3
{
    class Program
    {
        static public string password;
        
        class lockedBufor
        {
            static string bufor = "";
            
            static public void checkPassword()
            {
                lock (bufor)
                {
                    if (bufor == password) Console.WriteLine("Correct password: " + password);
                    consumentThread.Abort();
                    producentThread.Abort();
                }
            }

            static public void setBufor(string str)
            {
                lock (bufor)
                {
                    bufor = str;
                }
            }
        }
        
        static Thread producentThread;
        static Thread consumentThread;

        static void passwordGenerator(int length)
        {
            Random letter = new Random();
            char[] char_password = new char[length];

            for (int i = 0; i < length; i++)
            {
                char_password[i] = (char)letter.Next(33, 125);
            }

            password = new String(char_password);

            Console.WriteLine("Password generated: " + password);
        }

        static public void Producent()
        {
            char[] char_password = new char[password.Length];
            Random letter = new Random();
            while (true)
            {
                for (int j = 0; j < password.Length; j++)
                    char_password[j] = (char)letter.Next(33, 125);

                lockedBufor.setBufor(new String(char_password));
            }
        }

        static public void Consument()
        {
            while (true)
            {
                lockedBufor.checkPassword();
            }
        }

        static void Main(string[] args)
        {
            passwordGenerator(3); 

            producentThread = new Thread(Producent);
            consumentThread = new Thread(Consument);

            producentThread.Start();
            consumentThread.Start();

            Console.ReadLine();
        }
    }
    
}
