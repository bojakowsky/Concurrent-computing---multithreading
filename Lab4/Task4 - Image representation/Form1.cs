using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
namespace Task4___Image_representation
{
    public partial class Form1 : Form
    {
        static public bool go = false;

        static int n = 10;
        bool[,] array = new bool[n, n];
        bool[,] next_array = new bool[n, n];

        public Thread loop;
        public Thread[,] threads;

        public Graphics g;
        public Pen pen;
        public Rectangle rect;
        public Form1()
        {
            InitializeComponent();
        }

        public void initializeMap()
        {
            pen = new Pen(Color.Black, 5);
            rect = new Rectangle(0, 0, 500, 500);
            g.Clear(Color.White);
            g.DrawRectangle(pen, rect);
            int add = 500/n;
            for (int i = 0; i < 500; i += add )
            {
                g.DrawLine(pen, 0, i, 500, i);
                g.DrawLine(pen, i, 0, i, 500);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!go)
            {
                initializeMap();
                go = true;
                loop = new Thread(GameOfLifeLoop);
                loop.Start();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
        }


        void generateMap()
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    array[i, j] = rand.NextDouble() >= 0.5;
        }

        void printOutArray()
        {
            while (go)
            {
                int add = (500 / n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (array[i, j] == true)
                        {
                            SolidBrush blueBrush = new SolidBrush(Color.Black);
                            g.FillRectangle(blueBrush, i * add, j * add, add, add);
                        }
                        else
                        {
                            SolidBrush blueBrush = new SolidBrush(Color.White);
                            g.FillRectangle(blueBrush, (i * add) + 4 , (j * add) + 4 ,  add - 6, add - 6);
                        }
                    }
                }
                
            }

        }

        int returnNumberOfNeighbours(int x, int y)
        {
            int howMany = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == -1 || j == -1) continue;
                    else if (i == n|| j == n) continue;
                    else if (i == x && j == y) continue;
                    if (array[i, j ] == true)
                        howMany++;
                }
            }
            return howMany;
        }
        void liveOrDie(object obj_x, object obj_y)
        {
            int x = (int)obj_x;
            int y = (int)obj_y;

            if (x == n || y == n) return;
            int neighbours = returnNumberOfNeighbours(x, y);
            if (array[x, y] == false && neighbours == 3)
                next_array[x, y] = true;
            else if (array[x, y] == true && (neighbours == 2 || neighbours == 3))
            { next_array[x, y] = true; }
            else next_array[x, y] = false;
        }

        void copy(bool[,] a, bool[,] n_a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = n_a[i, j];
                }
            }
        }

        public void GameOfLifeLoop()
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

            threads = new Thread[n, n];
            while (go)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Thread.Sleep(10);
                        threads[i, j] = new Thread(() => liveOrDie(i, j));
                        threads[i, j].Start();
                        
                    }
                }
                Thread.Sleep(10);
                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            threads[i, j].Join();
                        }
                    }
                }
                catch (Exception)
                {

                    ////...
                }
                Thread.Sleep(10);
                copy(array, next_array);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {

            go = false;

            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        threads[i, j].Join();

                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    loop.Join();
                }
                catch (Exception)
                {

                }
                    
            }
            Thread.Sleep(1000);
            
            initializeMap();
            

            

        }

    }
}
