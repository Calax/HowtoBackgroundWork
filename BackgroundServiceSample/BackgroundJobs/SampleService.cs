using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

public class SampleService : BackgroundService
{
    private readonly SampleServiceSettings _settings;

    public SampleService(IOptions<SampleServiceSettings> settings)
    {
        _settings = settings.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            DoJob();

            await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
        }
    }

    private void DoJob()
    {
        
    }

    //protected override async Task StopAsync (CancellationToken stoppingToken)
    //{
    //    Run your graceful clean-up actions
    //}
}