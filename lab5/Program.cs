using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = 0;
            String str = null;

            if (args.Length < 0)
            {
                Console.Write("\nError, write -? or - help to see how to work with programm.\n");
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-?" || args[i] == "-help" || args[i] == "-h")
                {
                    HelpUser();
                }
            }

            while ((str = Console.ReadLine()) != null)
            {
                countOfLines++;
                FindIntegerInFile(str);
            } 

            Console.WriteLine("Count of new lines in file = {0}.", countOfLines);   
        }

        static void HelpUser()
        {
            Console.WriteLine("_______________________________" +
                "\nI`m programm which working with file.\n" +
                "I should find in the file only integer numbers." +
                "\nKeys:" +
                "\n[-h],[-?],[-help] - to open help.\n" +
                "________________________________________");
        }


        static void FindIntegerInFile(string word)
        {
            int number = 0;

            if (word.IndexOf('#') > -1)    // сделать отдельную функцию, ибо будет использовано и в других лабах
            {
               word = word.Remove(word.IndexOf('#'));    
            }

            string[] words = word.Split(' ');     // делает лишнюю работу, нужно добавлять ещё символы , /t и тд.

            for(int i = 0; i < words.Length; i++)
            {
                bool result = Int32.TryParse(words[i], out number);

                if (result)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
















/*
  if (args[i] == "-s")
                {
                    int number;
                    int countOfNewLines = 0;
                    string nameOFfile = args[i + 1];
                    string[] file = File.ReadAllLines(Convert.ToString(nameOFfile));                       // чтение файла построчно  // сделать только рид лайном, без рид алл лайнс

                    for (int j = 0; j < file.Length; j++)
                    {
                        for (int k = 0; k < file[j].Length; k++)
                        {
                            if (file[j][k] == '#')         // резаный массив jagged array   // найти функцию в мсдн, индекс оф, субсринг и тд, не делать в ручную
                            {
                                continue;
                            }
                            else if (file[j][k] != ' ')
                            {
                               char[] wordArray = new char[file[j].Length];

                                for (int l = 0; l < wordArray.Length; l++)
                                {
                                    wordArray[l] = file[j][k];
                                }

                                string s = new string(wordArray);
                                bool result = Int32.TryParse(s, out number);

                                if (result)
                                {
                                    Console.WriteLine(number);
                                }
                            }
                        }
                        countOfNewLines++;
                    }
                    Console.WriteLine("\nCount of new lines in the file = " + countOfNewLines);
                }
                else
                    
     
     */
