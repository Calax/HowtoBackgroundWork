using System;
using System.Threading;

namespace ScheduleWithTaskDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main started!");

            var cts = new CancellationTokenSource(5000); // Work for 5 sec
            var man = new TaskManager();
            man.StartJob(2000, 1000, cts.Token);
            
            Thread.Sleep(15000);
            Console.WriteLine("Main awakened");
        }
    }
}
