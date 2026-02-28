namespace FarmSim.Runtime.Hosted;
public class GameTimerHostedService(IGameTickRunner tick) : BackgroundService
{
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await tick.InitializeAsync(cancellationToken);
        await base.StartAsync(cancellationToken);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await tick.TickOnceAsync();
            }
            catch
            {
                // ignore
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}