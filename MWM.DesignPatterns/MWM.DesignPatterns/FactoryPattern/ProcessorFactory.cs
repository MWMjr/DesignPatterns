using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.FactoryPattern
{
    public static class ProcessorFactory
    {
        public static IProcessor CreateProcessor(string type)
        {
            IProcessor processor = null;
            switch(type.ToLower())
            {
                case "file":
                    processor = new FileProcessor();
                    return processor;
                case "ftp":
                    processor = new FTPProcessor();
                    return processor;
                default:
                    return null;
            }
        }
    }
}
