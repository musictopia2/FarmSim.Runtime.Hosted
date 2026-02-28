namespace FarmSim.Runtime.Hosted;
public static class ServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFarmSimHostedRuntime()
        {
            services.AddHostedService<GameTimerHostedService>();
            return services;
        }
    }
}