using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ScheduleWithManualResetEvent
{
    public class TaskManager
    {
        private ManualResetEvent _mre = new ManualResetEvent(false);
        private ConcurrentQueue<string> _works;
        public TaskManager()
        {
            Thread t = new Thread(ThreadProc);
            t.Start();

            _works = new ConcurrentQueue<string>();
            _works.Enqueue("w1");
            _works.Enqueue("w2");

            _mre.Set();
        }

        public void AddWork(string work){
            _works.Enqueue(work);
            Console.WriteLine($"{Thread.CurrentThread.Name} added work {work}");
            _mre.Set();
        }

        private void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            while (true)
            {
                Console.WriteLine(name + " starts and calls mre.WaitOne()");
                _mre.WaitOne();

                while (_works.Count > 0)
                {
                    Console.WriteLine(name + " starts sleeping as doing some work");
                    Thread.Sleep(5000);
                    if (_works.TryDequeue(out var res))
                        Console.WriteLine(name + " successfully dequeued " + res);
                }

                Console.WriteLine(name + " ends.");
                _mre.Reset();
            }
        }
    }
}