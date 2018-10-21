using System;
using System.Threading;

namespace ScheduleWithManualResetEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main launched!");
            var man = new TaskManager();
            Thread.Sleep(15000);
            Console.WriteLine("Main awakened");
            man.AddWork("w3");
        }
    }
}
