﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MoreLinq;
using static System.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        int GetPopulation(string name);
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
        private static int instanceCount;
        public static int Count => instanceCount;

        private SingletonDatabase()
        {
            instanceCount++;
            Console.WriteLine("Initializing database");
       
         capitals = System.IO.File.ReadAllLines(System.IO.Path.Combine(new System.IO.FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName + "..\\..\\..\\Singleton", "capitals.txt"))
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

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);
            return result;
        }
    }

    [TestClass]
    public class SingletonTest
    {
        [TestMethod]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.AreEqual(db, db2);
            Assert.AreEqual(SingletonDatabase.Count, 1);
        }

        [TestMethod]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            // This is an example of a bad idea - here I am dependent on data in a "live" database (granted our pretend one)

            // Problem here is that I cannot get a connection to a pretend database because the Singleton in effect has hard coded a reference to the database
            // It cannot be tested this way reliably
            Assert.AreEqual(tp, 17500000 + 17400000);
        }

    }

    static class Progranm
    {
        static void MainSingleton(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokypo";
            System.Console.WriteLine($"{city} has population {db.GetPopulation(city)}");

        }
    }
}
