using System;
using System.Threading;

namespace ScheduleWithTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var man = new TaskManager();
            man.SetTimer();
            
            Thread.Sleep(15000);
            
            Console.WriteLine("Main awakened");
        }
    }
}
