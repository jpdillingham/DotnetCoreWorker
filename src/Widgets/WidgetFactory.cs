using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreWorker.Widgets
{
    public class WidgetFactory : IWidgetFactory
    {
        private IServiceProvider ServiceProvider { get; }

        public WidgetFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IWidget GetWidget<T>() where T : IWidget
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }
    }
}
