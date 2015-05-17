using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task1___Thread_managing_window_app
{
    class ThreadingClass
    {
        private readonly Action _loopedAction;
        private bool _pause = false;
        private bool _exit = false;
        private object _threadLock = new object();

        private Thread thread;

        public ThreadingClass(Action action)
        {
            _loopedAction = action;
            thread = new Thread(RunThread);
        }

        public void Start()
        {
            thread.Start();
        }

        public void Stop()
        {
            _exit = true;
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

        private void RunThread()
        {
            while (true)
            {
                if (_pause)
                {
                    lock (_threadLock)
                    {
                        Monitor.Wait(_threadLock);
                    }
                }

                if (_exit)
                {
                    break;
                }

                _loopedAction();
            }
        }
    }
}
