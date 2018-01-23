using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.Builder
{
    /*
     *  Builder Pattern
     *
     *  Builder provides an API for constructing an object step-by-step because piecewise object construction
     *  is too complicated
     * 
     *  What's the reason for existing
     *  - Some objects are simple and can be created in a single constructor call
     *  - Other objects require a lot of ceremony to create
     *  - Having an object with 10 constructor arguments is not productive
     *  - Opt for piecewise construction
     *    
     */
    public class Main
    {
        static void MainWithBuilder(string[] args)
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello");
            builder.AddChild("li", "World");
            Console.WriteLine(builder.ToString());
        }
    }
}
