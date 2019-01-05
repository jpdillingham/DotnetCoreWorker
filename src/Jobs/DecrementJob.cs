namespace DotnetCoreWorker.Jobs
{
    using DotnetCoreWorker.Repositories;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DecrementJob : IDecrementJob
    {
        private ICountRepository Repository { get; }
        private ILogger Logger { get; }
        private Timer Timer { get; set; }

        public DecrementJob(ILogger<DecrementJob> logger, ICountRepository repository)
        {
            Logger = logger;
            Repository = repository;
            
            Logger.LogDebug($"Init {GetType().Name}");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogDebug($"Starting...");

            Timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            await Task.Yield();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogDebug("Stopping...");
            await Task.Yield();
        }

        private void DoWork(object state)
        {
            Repository.Decrement(1);
            Logger.LogDebug($"Counter value is now {Repository.Count}");
        }
    }
}
