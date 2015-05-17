using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Numerics;
namespace Task1___Thread_managing_window_app
{
    public partial class App : Form
    {

#region lock_section

        //private readonly Action _loopedAction;
        private bool _pause = false;
        private bool _exit = false;
        private object _threadLock = new object();

        private Thread thread;
        
        public void Start()
        {
            result = 1;
            AppendTextBox(result.ToString());
          

            thread = new Thread(calcPermutation);
            thread.Start();
           
            
        }

        public void Stop()
        {
            result = 1;
            AppendTextBox(result.ToString());
            if (!_exit)
                _exit = true;
            else _exit = false;
            ResetAll();
        }

        public void Resume()
        {
            ResumeThread();
        }

        public void Pause()
        {
            PauseThread();
        }

        private void PauseThread()
        {
            _pause = true;
        }

        private void ResumeThread()
        {
            _pause = false;
            lock (_threadLock)
            {
                Monitor.Pulse(_threadLock);
            }
        }
#endregion

        BigInteger result = 1;
        bool isStarted = false;
        bool isPaused = false;
        decimal n;
        

        public App()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void calcPermutation()
        {
            return_nTextBox();
            setProgressMaxAndStep(n, 1);
            AppendTextBoxEndTime((n * 200).ToString());
            
            for (decimal i = 2; i <= n ; i ++)
            {
                if (_pause)
                {
                    AppendTextBox(result.ToString());
                    lock (_threadLock)
                    {
                        Monitor.Wait(_threadLock);
                    }
                }

                if (_exit)
                {
                    break;
                }

                result = BigInteger.Multiply(result, new BigInteger ( i ));
                progressStep();
                AppendTextBox(result.ToString());
                AppendTextBoxBeginTime((i * 200).ToString());
                Thread.Sleep(200);
            }
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                Start();
                isStarted = true;
            }
            else
            {
                isStarted = false;
                Stop();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                Pause();
                isPaused = true;
            }
            else
            {
                Resume();
                isPaused = false;
            }
            //
            AppendTextBox(result.ToString());
        }

        private void begin_time_label_Click(object sender, EventArgs e)
        {

        }

    }
}
