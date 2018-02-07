using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns
{
    class Program
    {
        static void MainFactory(string[] args)
        {
            MWM.DesignPatterns.FactoryPattern.Main fp = new FactoryPattern.Main();
            fp.Run();
        }
    }
}
