using System;
using System.Threading;

namespace ScheduleWithTimer
{
    public class TaskManager
    {
        private const int _interval = 1000;
        private Timer _timer;

        public void SetTimer()
        {
            _timer = new Timer(ProcessTick, null, _interval, Timeout.Infinite);
        }

        private void ProcessTick(object state)
        {
            try
            {
                Console.WriteLine("Tick done.");
            }
            finally
            {
                _timer?.Change(_interval, Timeout.Infinite);
            }
        }
    }
}