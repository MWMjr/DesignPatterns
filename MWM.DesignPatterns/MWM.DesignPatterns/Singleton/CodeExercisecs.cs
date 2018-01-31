using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Since implementing a singleton is easy, you have a different challenge: write a method called IsSingleton() . 
 * This method takes a factory method that returns an object and it's up to you to determine whether or not that 
 * object is a singleton instance.
 * 
 * using System;

  namespace Coding.Exercise
  {
    public class SingletonTester
    {
      public static bool IsSingleton(Func<object> func)
      {
        // todo
      }
    }
  } 
 * 
 */

namespace MWM.DesignPatterns.Singleton.Exercise
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var obj1 = func.Invoke();
            var obj2 = func.Invoke();

            return obj1 == obj2;
        }
    }
}

// This was the correct answer, and I actually got it right first time (Beginner's luck)
