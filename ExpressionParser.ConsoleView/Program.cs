using System;
using ExpressionParser.ParserLibrary.Mode;
using ExpressionParser.ParserLibrary.Parser;

namespace ExpressionParser.ConsoleView
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new ExpressionParser<int>().Parse("x + 2");
            Console.WriteLine(result.Evaluate(1, 2, 3, new IntMode()));
        }
    }
}