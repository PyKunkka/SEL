using System;

namespace ThirdProjectV0._1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)                                          // проверка на то, пустая ли строка
                Console.WriteLine("Строка пустая, введите пожалуйста хоть что то :).");
            else
            {
                int num = 0,
                    count = 0;
                string str = "";

                for (int i = 0; i < args.Length; i++)
                    str = args[i];


                for (int j = 0; j < str.Length; j++)
                {
                    if (Char.IsDigit(str[j]) || str[j] == '-')
                        num++;
                    if (str[j] == ' ')
                        count++;
                }

                string joinStr = String.Join(";",args);

                Console.WriteLine(joinStr);   // вывод введеной строки + join(contact)

                Console.WriteLine("Строка в верхнем регистре: " + joinStr.ToUpper());         // вывод строки в верхнем регистре

                Console.WriteLine("Длинна строки = " + joinStr.Length);       // вывод длинны строки




                if (str.Length > 5)
                    Console.WriteLine("5-6 символ = [{0}]", str.Substring(5, 2));   // вывод 5-6 символа

                if (num == str.Length)
                {
                    Console.WriteLine("Это число");
                    num = 0;
                }

                Console.WriteLine("Количество пробелов: {0}", count);      // вывод количества пробелов
            }
        }
    }
}
