using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfixToPostfix1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите инфиксное выражение");
            string line = Console.ReadLine();
            string result = InfixToPostfixConverter.Convert(line);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
