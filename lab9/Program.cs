using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    struct x : IComparable<x>
    {
        public string s;
        public int i;
        static public int sortOrder;

        public int CompareTo(x other)
        {
            Console.Error.WriteLine("sort order {0}", sortOrder);

            if (sortOrder == 0)
            {
                return i.CompareTo(other.i);
            }
            else
                return s.CompareTo(other.s);
        }

        public x(string s, int i)
        {
            this.s = s;
            this.i = i;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            x[] arr = new x[4];
            arr[0] = new x("one", 123);
            arr[1] = new x("two", 345);
            arr[2] = new x("three", 7);
            arr[3] = new x("four", 1);

            foreach(x i in arr)
            {
                Console.WriteLine("{0} : {1}", i.s, i.i);
            }
            Array.Sort(arr);

            foreach(x i in arr)
            {
                Console.WriteLine("{0} : {1}", i.s, i.i);
            }

            x.sortOrder = 1;
            Array.Sort(arr);

            foreach (x i in arr)
            {
                Console.WriteLine("{0} : {1}", i.s, i.i);
            }
        }
    }
}
