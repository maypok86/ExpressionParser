using System;
using System.Runtime.InteropServices;

namespace ExpressionParser.ParserLibrary.Mode
{
    public class IntMode : Mode<int>
    {
        private void CheckZero(int value)
        {
            if (value == 0)
            {
                throw new DivideByZeroException();
            }
        }
        
        public override int Add(int first, int second) => first + second;

        public override int Subtract(int first, int second) => first - second;

        public override int Multiply(int first, int second) => first * second;

        public override int Divide(int first, int second)
        {
            CheckZero(second);
            return first / second;
        }

        public override int Mod(int first, int second)
        {
            CheckZero(second);
            return first % second;
        }

        public override int Negate(int value) => -value;

        public override int Abs(int value) => Math.Abs(value);

        public override int Parse(string number) => int.Parse(number);

        public override int Value(int number) => number;
    }
}