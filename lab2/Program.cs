using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] array = new bool[1000];
            var date1 = DateTime.Now;

            for (int i = 2; i < 1000; i++)
                array[i] = true;


            for (int i = 2; i < Math.Sqrt(1000) + 1; ++i)
            {
                if (array[i])
                {
                    for (int j = i * i; j < 1000; j += i)
                        array[j] = false;
                }
            }
 
            for (int i = 2; i < 1000; i++)
            {
                if (array[i])
                    Console.WriteLine("{0} ", i);
            }

            var date2 = DateTime.Now;
            TimeSpan span = date2 - date1;
            double seconds = span.TotalSeconds;
            
            Console.WriteLine("\nВремя роботы программы = {0}", seconds);
        }
    }
}