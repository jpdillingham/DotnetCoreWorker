namespace DotnetCoreWorker.Jobs
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class IncrementJob : IIncrementJob
    {
        private ICountRepository Repository { get; }

        public IncrementJob(ICountRepository repository)
        {
            Repository = repository;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
