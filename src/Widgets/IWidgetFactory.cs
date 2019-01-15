using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreWorker.Widgets
{
    public interface IWidgetFactory
    {
        IWidget GetWidget<T>() where T : IWidget;
    }
}
