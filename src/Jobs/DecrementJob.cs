namespace DotnetCoreWorker.Jobs
{
    using DotnetCoreWorker.Repositories;
    using DotnetCoreWorker.Widgets;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DecrementJob : IDecrementJob
    {
        private ICountRepository Repository { get; }
        private ILogger Logger { get; }
        private Timer Timer { get; set; }

        //public DecrementJob(ILogger<DecrementJob> logger, ICountRepository repository, WidgetOne widgetOne, WidgetTwo widgetTwo)
        //{
        //    Logger = logger;
        //    Repository = repository;

        //    widgetOne.SayStuff();
        //    widgetTwo.SayStuff();

        //    Logger.LogDebug($"Init {GetType().Name}");
        //}

        //public DecrementJob(ILogger<DecrementJob> logger, ICountRepository repository, IServiceProvider serviceProvider)
        //{
        //    Logger = logger;
        //    Repository = repository;

        //    ((WidgetOne)serviceProvider.GetService(typeof(WidgetOne))).SayStuff();
        //    ((WidgetTwo)serviceProvider.GetService(typeof(WidgetTwo))).SayStuff();

        //    Logger.LogDebug($"Init {GetType().Name}");
        //}

        //public DecrementJob(ILogger<DecrementJob> logger, ICountRepository repository, IWidgetFactory widgetFactory)
        //{
        //    Logger = logger;
        //    Repository = repository;

        //    widgetFactory.GetWidget<WidgetOne>().SayStuff();
        //    widgetFactory.GetWidget<WidgetTwo>().SayStuff();

        //    Logger.LogDebug($"Init {GetType().Name}");
        //}

        public DecrementJob(ILogger<DecrementJob> logger, ICountRepository repository, IWidget widget)
        {
            Logger = logger;
            Repository = repository;

            widget.SayStuff();

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
