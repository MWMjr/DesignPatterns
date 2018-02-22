using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JetBrains.dotMemoryUnit;

namespace MWM.DesignPatterns.Flyweight
{
    // Flyweight

    // Goal is to eliminate redundancy when storing data
    // i.e. storing first and last names - theres going to be a lot of "John"s

    // .NET performs string interning, so an identical string is stored only once

    // e.g. bold or italic text in the console
    // - Don't want each character to have a formatting character
    // - instead operate on ranges


    // A space optimization technique that lets us use less memory by storing externally the data assocaited with similar objects


    //Repeating User Names Example
    //This is the regular way
    public class User
    {
        private string fullName;

        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }

    // This is the flyweight
    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;

        public User2(string fullName)
        {
            int getOrAdd(string s)
            {
                int index = strings.IndexOf(s);
                if (index != -1) return index;
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(" ",
            names.Select(i => strings[i]));
    }

    [TestFixture]
    public class Demo
    {
        static void FlyweightMain(string[] args)
        {

        }

        [Test]
        public void TestUser()  // 1655033 Memory Used
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User>();

            foreach(var firstName in firstNames)
                foreach(var lastName in lastNames)
                    users.Add(new User($"{ firstName } { lastNames}"));

            ForceGC();

            dotMemory.Check(memory =>
            {
                Console.WriteLine(memory.SizeInBytes);
            });
        }

        [Test]
        public void TestUser2()  // 1296991 Memory Used is 300J less
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User2>();

            foreach (var firstName in firstNames)
                foreach (var lastName in lastNames)
                    users.Add(new User2($"{ firstName } { lastNames}"));

            ForceGC();

            dotMemory.Check(memory =>
            {
                Console.WriteLine(memory.SizeInBytes);
            });
        }

        private void ForceGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private string RandomString()
        {
            Random rand = new Random();
            return new string(
                Enumerable.Range(0,10)
                .Select(i => (char)('a' + rand.Next(26)))
                .ToArray());
        }
    }
}
