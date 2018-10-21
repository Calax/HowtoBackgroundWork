using System;
using System.Threading;
using System.Threading.Tasks;

public class TaskManager
{
    public void StartJob(int delayMs, int repeatMs, CancellationToken ct)
    {
        try
        {
            DoJob(delayMs, repeatMs, ct).Wait();
        }
        catch (AggregateException ae)
        {
            ae.Handle(e => e is TaskCanceledException);
        }
    }

    private static async Task DoJob(int delayMs, int repeatMs, CancellationToken ct)
    {
        await Task.Delay(delayMs, ct);

        while (!ct.IsCancellationRequested)
        {
            Console.WriteLine("{0}: Repeating every 1 sec", DateTime.Now);
            await Task.Delay(repeatMs, ct);
        }
    }
}
