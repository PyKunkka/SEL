using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 1000; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine(i);
            }


            Console.WriteLine("_________________________");


            for (int i = 2; i <= 1000; i++)
            {
                int num = 0;
                for (int j = 2; j <= (i / 2); j++)
                {
                    num = 0;
                    if (i % j == 0)
                    {
                        num++;
                        break;
                    }


                }
                if (num != 0)
                    continue;
                else
                    Console.WriteLine(i);
            }
        }
    }
}
