using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.Composite
{
    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other)) return;

            foreach (var from in self)
            {
                foreach(var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
            }
        }
    }

    public class Neuron : IEnumerable<Neuron> // This is the solutioin, make Neuron an IEnumerable
    {
        public float Value;
        public List<Neuron> In, Out;


        //Replaced by above extension method
        //public void ConnectTo(Neuron other)
        //{
        //    Out.Add(other);
        //    other.In.Add(this);
        //}

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        // What is yield? When you use the yield keyword in a state,emt, you indicate that the method, operator, or get accessor in
        // which it appears is an iterator.  Using yield to define an iterator removes the need for an explicit extra class (which
        // hold s the state for an enumeration) when you implement the IEnumerable and Ienumerator pattern for a custom collection type

        // a 'yield return' statement returns each element one at a time
        // a 'yield break' statement ends the iteration

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {

    }

    // We have to treat Neuron and Neuron Layer as the same thing, but how, we can't fit a new base class into it
    // because NeuronLayer already has one

    // solution is to treat Neuron as a collection of a single unit

    static class ProgramNN
    {
        static void MainNN(string[] args)
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2); //1

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            // now takes 4 connect


            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
        }
    }
}
