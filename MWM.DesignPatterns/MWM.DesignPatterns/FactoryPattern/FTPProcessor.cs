using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.FactoryPattern
{
    public class FTPProcessor : IProcessor
    {
        public string Name
        {
            get
            {
                return "FTP Processor";
            }
        }

        public string ReadText()
        {
            return "This is some text from an FTP source";
        }

        public void SaveText(string text)
        {
            //Pretend to save some text to a file
        }
    }
}
