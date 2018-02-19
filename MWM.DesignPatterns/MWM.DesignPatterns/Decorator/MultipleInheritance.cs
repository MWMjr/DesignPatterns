using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.Decorator
{
    // It can be done via interfaces, but it gets wonky quickly - see the setter for Weight, which is 
    // part of each interface

    public class Bird : IBird
    {
        public void Fly()
        {
            System.Console.WriteLine($"Soaring in the sky with weight {Weight}");
        }

        public int Weight { get; set; }
    }

    public class Lizard : ILizard
    {
        public void Crawl()
        {
            System.Console.WriteLine($"Crawling in the dirt with weight {Weight}");
        }

        public int Weight { get; set; }
    }

    //public Dragon : Bird, Lizard  ---   Can't do this
    // Solution is to turn both into interfaces, because you can inherit multiple interfaces

    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }

    public class Dragon : IBird, ILizard
    {
        //Can just copy the methods into this class, but that duplicates code
        private Bird bird;
        private Lizard lizard;

        public Dragon()
        {
            // Can use DI to get these from constructor
            this.bird = new Bird();
            this.lizard = new Lizard();
        }

        public void Fly()
        {
            bird.Fly();
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        //Satist the interface like so
        public int Weight {
            get
            {
                return _weight;
            }
            set
            {
                Weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }
        private int _weight;

        // Do not satisfy the interface like this - it will lead to issues
        // i.e. Weight cannot be public because it is defined in an explicit interface
        //int ILizard.Weight
        //{
        //    get { }
        //    set { }
        //}

        //int IBird.Weight
        //{
        //    get { }
        //    set { }
        //}
    }

    static class MultipleInheritanceProgram
    {
        static void Main(string[] args)
        {
            Dragon d = new Dragon();
            d.Weight = 123;
            d.Fly();
            d.Crawl();            
        }
    }
}
