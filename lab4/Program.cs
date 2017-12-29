using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Examlpe1       
    {
        public int num1;
    }

    public struct Example2 
    {
        public int num2;
    };

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 34, -1, 23 };
            int number1 = 19;

            Console.WriteLine("Заданый массив.");
            foreach (int i in arr1)
                Console.Write(i + " ");
            Console.WriteLine("\nЗаданое число = " + number1);

            Console.WriteLine(new string('-', 15));

            Console.WriteLine("Вывод значений массива после ref. (если ref сработал, значения равны 1, если нет 0)");
            func(arr1, number1);
            foreach (int i in arr1)
                Console.Write(i+ " ");
            Console.WriteLine("\nЗаданое число после ref (если ref сработал, то значение 1) = " + number1);

            Console.WriteLine(new string('-', 15));

            string[] arr3 = new string[] { "one", "two", "three" };
            string word1 = "Hello";

            Console.WriteLine("Заданый массив.");
            foreach (string word in arr3)
                Console.Write(word + " ");
            Console.WriteLine("\nЗаданое слово = " + word1);

            Console.WriteLine(new string('-', 15));

            func(arr3, word1);
            Console.WriteLine("Вывод значений аргументов после ref. (если ref сработал то значения равны 1, если нет 0)");
            foreach (string word in arr3)
                Console.Write(word + " ");
            Console.WriteLine("\nЗаданое слово после ref (если ref сработал, то значение 1) = " + word1);

            Console.WriteLine(new string('-', 15));

            Examlpe1 x = new Examlpe1();
            Examlpe1 x1 = new Examlpe1();
            Examlpe1 x2 = new Examlpe1();
            Examlpe1 x3 = new Examlpe1();

            x.num1 = 0;
            x1.num1 = 0;
            x2.num1 = 0;
            x3.num1 = 0;

            funct1(x, ref x1, x2, ref x3);
            Console.WriteLine("Class: {0} , {1}, {2} , {3}", x.num1, x1.num1, x2.num1, x3.num1);

            Console.WriteLine(new string('-', 15));

            Example2 y = new Example2();
            Example2 y1 = new Example2();
            Example2 y2 = new Example2();
            Example2 y3 = new Example2();

            y.num2 = 0;
            y1.num2 = 0;
            y2.num2 = 0;
            y3.num2 = 0;

            funct2(y, ref y1, y2, ref y3);
            Console.WriteLine("Class: {0} , {1}, {2} , {3}", y.num2, y1.num2, y2.num2, y3.num2);

            Console.WriteLine(new string('-', 15))
        }

        static void funct2(Example2 y, ref Example2 y1, Example2 y2, ref Example2 y3)
        {
            y.num2 = 1;
            y1.num2 = 1;

            y2 = new Example2();
            y3 = new Example2();

            y2.num2 = 1;
            y3.num2 = 1;
        }

        static void funct1(Examlpe1 x, ref Examlpe1 x1, Examlpe1 x2, ref Examlpe1 x3)
        {
            x.num1 = 1;
            x1.num1 = 1;
            x2 = new Examlpe1();
            x3 = new Examlpe1();
            x2.num1 = 1;
            x3.num1 = 1;
        }

        static void func(int[] array, int num)
        {
            for(int i = 0; i<array.Length ;i++)
            {
                array[i] = 1;
            }
            num = 1;
        }

        static void func(string[] array, string str1)
        {
            for(int i = 0; i<array.Length;i++)
            {
                array[i] = "1";
            }
            str1 = "1";
        }
    }
}
