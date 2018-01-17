using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.FactoryPattern
{
    public interface IProcessor
    {
        string ReadText();
        void SaveText(string processText);
        
        string Name { get; }
    }
}
