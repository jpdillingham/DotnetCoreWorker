namespace DotnetCoreWorker.Jobs
{
    using DotnetCoreWorker.Repositories;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    public class IncrementJob : IIncrementJob
    {
        private ICountRepository Repository { get; }
        private ILogger Logger { get; }

        public IncrementJob(ILogger<IncrementJob> logger, ICountRepository repository)
        {
            Logger = logger;
            Repository = repository;

            Logger.LogDebug($"Init {GetType().Name}");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogDebug($"Starting...");
            await Task.Yield();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogDebug("Stopping...");
            await Task.Yield();
        }
    }
}
