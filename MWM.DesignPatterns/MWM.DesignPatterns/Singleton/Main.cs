using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.Singleton
{
    /*
     *  Singleton Pattern
     * 
     *  A component which is instantiated only once
     * 
     *  For some components it only makes sense to hae on in the system
     *  
     * (i.e. Database repository, Object factory (why have multiple of a class that builds an object)
     * 
     * The constructor call is expensive
     *  - We only do it once
     *  - We provide everyone with the same instance
     *  
     *  Want to prevent anyone creating additional copies
     *  Need to take care of lazy instantiation and thread safety
     *       
     */
     
    public interface IDatabase
    {
        int GetPopulation(string name)
    }
    

    public class NotASingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        public NotASingletonDatabase()
        {
            Console.WriteLine("Initializing database");
            capitals = System.IO.File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }
               
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }


    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private SingletonDatabase()
        {
            Console.WriteLine("Initializing database");

            capitals = System.IO.File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }

    static class Progranm
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokypo";
            System.Console.WriteLine($"{city} has population {db.GetPopulation(city)}");

        }
    }
}
