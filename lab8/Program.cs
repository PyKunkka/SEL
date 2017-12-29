using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace l8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool text2bin = false;                                            // булевые переменные для того, что бы понять какая работа должна будет 
                                                                              // выполняться
            bool bin2text = false;
            bool Fnumb = false;
            bool getNumb = false;
            bool verbose = false;

            string fileName = null;

            int numbers = -1;                                                  // -1 потому что если пользователь захочет -s 0 вывести
                                                                               // выводило не весь файл (велосипед)

            if (args.Length < 0)                                               // если ничего не было введено
            {
                Console.Write("\nError, write -? or - help to see how to work with programm.\n");
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-?" || args[i] == "-help" || args[i] == "-h")   // ключи для вывода хелпера
                {
                    HelpUser();
                }
                else if (args[i] == "-t2b")                                     // сделать из текст. бинарный  
                {
                    text2bin = true;
                }
                else if (args[i] == "-s" && args[i + 1] != null)                 // для вывода только заданого кол-ва чисел
                {
                    bool n = int.TryParse(args[i + 1], out numbers);

                    if (n)
                        getNumb = true;
                }
                else if (args[i] == "-b2t")                                     // из бинар. текстовый 
                {
                    bin2text = true;
                }
                else if (args[i] == "-rF")                                      // для чтения типа float чисел + int
                {
                    Fnumb = true;
                }
                else if (args[i] == "-v")                                       // для найденых ошибок 
                {
                    verbose = true;
                }
                else if (args[i] == "-f" && args[i + 1] != null)                 // для ввода файла
                {
                    if (File.Exists(args[i + 1]) == false)                       // проверям есть ли он
                    {
                        Console.WriteLine("\nError, file <{0}> is not exist", args[i + 1]);
                    }
                    else
                    {
                        fileName = args[i + 1];                                   // взяли имя файла

                        if (text2bin == bin2text)                                 // если пользователь хочет сразу и бинар. и текст. - ругаемся
                        {
                            Console.Write("\nError, write -? or - help to see how to work with programm.\n");
                        }

                        if (text2bin && getNumb)
                        {
                            ConvertToBin(fileName, numbers, Fnumb, verbose);       // конвертим в бин.
                        }
                        else if (bin2text && getNumb)
                        {
                            ConvertToText(fileName, numbers, Fnumb, verbose);      // конвертим в текст. 
                        }
                    }
                }
            }
        }

        static void ConvertToBin(string nameOfFile, int numberToinput, bool readFloat, bool verbos)
        {
            int nummOfStr = 0;                                                                     // номер строки, для вывода ошибки в строке
            string str = "";

            StreamReader file = new System.IO.StreamReader(nameOfFile);                             // читаем файл
            BinaryWriter writer = new BinaryWriter(File.Open("OutPutT2B.bin", FileMode.Create));    // создаём бинарный файл куда будем записовать

            while ((str = file.ReadLine()) != null)
            {
                str = RemoveComments(str);                                                          // удаляем комменты сразу из строки

                if (!string.IsNullOrEmpty(str))                                                     // пропускаем пустые строки
                {
                    str = Regex.Replace(str, "[ ]+", " ");                                          // убираем лишние пробелы между словами (нашел в интернете)
                                                                                                    // лишняя работа, но пусть будет
                    string[] arr = new string[str.Length];                                          // будем сплитить слова пробелами  
                    arr = str.Split(' ');
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i < numberToinput)                                                      // проверяем на нужное кол. для вывода
                        {
                            if (readFloat)                                                          // читаем всё
                            {
                                try
                                {
                                    double num = Double.Parse(arr[i]);
                                    writer.Write(num);
                                }
                                catch (FormatException)
                                {
                                    if (verbos)
                                    {
                                        Console.WriteLine("\t\t\t\t\t  <FormatException>");
                                        Console.WriteLine("\t\t\t\t\tError in line {0} with '{1}'.", nummOfStr, arr[i]);
                                    }
                                }
                                catch (OverflowException)
                                {
                                    if (verbos)
                                    {
                                        Console.WriteLine("\t\t\t\t\t  <OverflowException>");
                                        Console.WriteLine("\t\t\t\t\tError in line {0} with '{1}'.", nummOfStr, arr[i]);
                                    }
                                }
                            }
                            else                                                                      // читаем только инты
                            {
                                try
                                {
                                    int num = Int32.Parse(arr[i]);
                                    writer.Write(num);
                                }
                                catch (FormatException)
                                {
                                    numberToinput++;
                                    if (verbos)
                                    {
                                        Console.WriteLine("\t\t\t\t\t  <FormatException>");
                                        Console.WriteLine("\t\t\t\t\tError in line {0} with '{1}'.", nummOfStr, arr[i]);
                                    }
                                }
                                catch (OverflowException)
                                {
                                    numberToinput++;
                                    if (verbos)
                                    {
                                        Console.WriteLine("\t\t\t\t\t  <OverflowException>");
                                        Console.WriteLine("\t\t\t\t\tError in line {0} with '{1}'.", nummOfStr, arr[i]);
                                    }
                                }
                            }
                        }
                    }
                    nummOfStr++;
                }
            }
        }

        static void ConvertToText(string fileName, int numberToInput, bool readFloat, bool verbos)      // конвертим с бинар. в текст.
        {
            double x = 0;
            using (StreamWriter writer = new StreamWriter("OutPutB2T.txt"))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    try
                    {
                        while (reader.PeekChar() > -1)
                        {
                            for (int i = 0; i < numberToInput; i++)
                            {
                                if (readFloat)                                                                      // если читаем всё
                                {
                                    x = reader.ReadDouble();
                                    writer.WriteLine(x);
                                }
                                else                                                                                // только инты
                                {
                                    x = reader.ReadInt32();
                                    writer.WriteLine(x);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (verbos)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
    }

        static string RemoveComments(string str)                     // удаляем лишние пробелы, делаем трим и возвращаем ту же строку 
        {
            if (str.IndexOf('#') > -1)
            {
                str = str.Remove(str.IndexOf('#'));
            }

            return str.Trim(' ');                                    // возвращаем строку сразу без пробелов слева и справа
        }


        static public void HelpUser()                                // метод вывода подсказки
        {
            Console.WriteLine("\n----------This program converts text to binary and binary to text integer and float numbers from file.----------\n" + 
                "\n\t\tKeys:   \n" +
                "[-t2b] - to convert text file to binary.\n" +
                "[-b2t] - to convert binary file to text.\n" +
                "[-f] <file> - to take file for operations.\n" +
                "[-rF] - to read float number. (by default - int)\n" +
                "[-v] - verbose, to see Errors.\n" +
                "[-s] <number> - to take only <number> count in file.\n" +
                "\n----------Written by Oleksandr Kozachuk 2017.----------");
        } 
    }
}
 