using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.FactoryPattern
{
    interface IProcessorFactory
    {
        IProcessor CreateProcessor(string type);
    }
}
