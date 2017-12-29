using System;
using System.Linq;

namespace lab6
{
    class Program
    {
        static Operate operations;

        static void Main(string[] args)
        {
            operations = new Operate();

            operations.CheakArgsInNotEmptyOrNull(args);
            operations.CalculateWithHelper(args);
        }
    }
}