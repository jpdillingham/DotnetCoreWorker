﻿namespace DotnetCoreWorker.Jobs
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DecrementJob : IDecrementJob
    {
        private ICountRepository Repository { get; }

        public DecrementJob(ICountRepository repository)
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
