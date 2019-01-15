using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreWorker.Widgets
{
    public class WidgetOne : IWidget
    {
        private ILogger Logger { get; }
        private string Stuff { get; }

        public WidgetOne(ILogger<WidgetOne> logger, string stuff)
        {
            Logger = logger;
            Stuff = stuff;
        }

        public void SayStuff()
        {
            Logger.LogInformation(Stuff);
        }
    }
}
