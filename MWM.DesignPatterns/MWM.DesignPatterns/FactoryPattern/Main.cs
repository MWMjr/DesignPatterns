using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.FactoryPattern
{
    class Main : IPattern
    {
        public int Run()
        {
            IProcessor objFileProcessor = ProcessorFactory.CreateProcessor("file");

            Console.WriteLine(string.Format("The type of processor that was created is a {0}", objFileProcessor.Name));

            IProcessor objFTPProcessor = ProcessorFactory.CreateProcessor("FTP");

            Console.WriteLine(string.Format("The type of processor that was created is a {0}", objFTPProcessor.Name));
            return 1;
        }

    }
}
