using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Operate
    {
        public void CalculateWithHelper(string[] args1)
        {
            for (int i = 0; i < args1.Length; i++)
            {
                if (args1[i] == "-?" || args1[i] == "-help" || args1[i] == "-h" || args1[i] == "/h" || args1[i] == "/?")
                {
                    HelpUser();
                }
                else if ((args1[i] == "-add") && args1[i + 1] != null && args1[i + 2] != null)
                {
                    Console.Write(args1[i + 1] + " + " + args1[i + 2] + " = ");
                    AddTwoStringNumbers(args1[i + 1], args1[i + 2]);
                }
                else if ((args1[i] == "-sub") && args1[i + 1] != null && args1[i + 2] != null)
                {
                    Console.Write(args1[i + 1] + " - " + args1[i + 2] + " = ");
                    SubstractTwoStringNumbers(args1[i + 1], args1[i + 2]);
                }
            }
        }  // ключи, и запуск методов

        public void CheakArgsInNotEmptyOrNull(string[] args1)
        {
            if (args1.Length <= 0)
            {
                Console.Write("\nError, write -? or - help to see how to work with programm.\n");
            }
        } // проверка строки на то, что она не пустая

        private void AddTwoStringNumbers(string str1, string str2)
        {
            if (StrIsDigit(str1) && StrIsDigit(str2))
            {
                string result = "";
                int num1 = 0, num2 = 0;
                int max = Math.Max(str1.Length, str2.Length);       // выбор длинны максимума из 2 строк
                int number1, number2 = 0;

                AddStringLessNumToOperate(ref str1, ref str2, max);

                // вобщем нужно добавить ещё 1 0 в начало, если их длинна одинаковая но, сумма 2 последних больше 10
                if (str1.Length == str2.Length)
                {
                    if (str1[max - 1] + str2[max - 1] >= 10)
                    { 

                        str1 += "0";
                    }
                }

                for (int i = max - 1; i >= 0; i--)     // делаем суму элементов с конца
                {
                    number1 = (int)Char.GetNumericValue(str1[i]);
                    number2 = (int)Char.GetNumericValue(str2[i]);

                    num1 = (num2 + number1 + number2) % 10;
                    result += num1.ToString();
                    num2 = (num2 + number1 + number2) / 10;
                }
                Console.Write(new string(result.Reverse().ToArray()));   // вывод в обратном порядке наш result
            }
            else
            {
                Console.WriteLine("Error string convert to int.");
            }
        }  // сумма чисел (недоработано)

        private void SubstractTwoStringNumbers(string str1, string str2)
        {
            if (StrIsDigit(str1) && StrIsDigit(str2))
            {
                string result = "";
                int num1 = 0, num2 = 0;
                int max = Math.Max(str1.Length, str2.Length);
                int last = 0;
                int numer = str1.Length + str2.Length;

                if (numer == 2)
                {
                    Console.Write(Convert.ToInt16(str1) - Convert.ToInt16(str2));
                }
                else
                {
                    AddStringLessNumToOperate(ref str1, ref str2, max);

                    for (int i = max - 1; i >= 0; i--)
                    {

                        int numb1 = Convert.ToInt32(str1[i]) - last;
                        int numb2 = Convert.ToInt32(str2[i]);

                        if (numb1 - numb2 < 0)
                        {
                            if (numb1 < numb2)
                            {
                                numb1 += 10;

                                num1 = (num2 + numb1 - numb2) % 10;
                                result += num1.ToString();
                                num2 = (num2 + numb1 - numb2) / 10;
                            }
                            last = 1;
                        }
                        else
                        {
                            num1 = (num2 + (int)char.GetNumericValue(str1[i]) - (int)char.GetNumericValue(str2[i])) % 10;
                            result += (num1 - last).ToString();
                            num2 = (num2 + (int)char.GetNumericValue(str1[i]) - (int)char.GetNumericValue(str2[i])) / 10;

                            last = 0;
                        }
                    }
                    // ищем число от int i = 0 до result.Length, находим индекс первого эл. который отменный от нуля, и удаляем все до него!
                    Console.Write(new string(result.Reverse().ToArray()));
                }
            }
            else
            {
                Console.WriteLine("Error string convert to int.");
            }
        } // отнимание чисел (недоработано)

        private void HelpUser()
        {
            Console.WriteLine
                (
                "\n--Programm which should add or subtract two large numbers.--\n" +
                "         --Created by Oleksandr Kozachuk 2017.--" +
                "\nKeys:\n" +
                "\n[-h],[-?],[-help],[/h],[/?] - to open help.\n" +
                "\n[-add] number number - to add two large numbers.\n" +
                "\n[-sub] number number - to substract numbers.\n"
                );
            Environment.Exit(1);
        } // вывод помощника

        private bool StrIsDigit(string array)
        {
            bool val1 = true;

            for (int i = 0; i < array.Length; i++)
            {
                if (char.IsNumber(array[i]) != true)
                {
                    val1 = false;
                }
            }
            return val1;
        } // проверка на лишние символы числа

        private void AddStringLessNumToOperate(ref string word1, ref string word2, int max)
        {
            if (word1.Length < word2.Length)   // если вторая строка больше чем 1, мы слева добавляем нужно количество 0
            {
                word1 = word1.PadLeft(max, '0');
            }
            else if (word1.Length > word2.Length)       // аналогично, но только если 1 строка больше 2
            {
                word2 = word2.PadLeft(max, '0');
            }
        } // добавления 0 к числу, что бы числа были одной длинны
    }
}
