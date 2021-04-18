using System;

namespace ExpressionParser.ParserLibrary.Mode
{
    public class LongMode : Mode<long>
    {
        private void CheckZero(long value)
        {
            if (value == 0)
            {
                throw new DivideByZeroException();
            }
        }
        
        public override long Add(long first, long second) => first + second;

        public override long Subtract(long first, long second) => first - second;

        public override long Multiply(long first, long second) => first * second;

        public override long Divide(long first, long second)
        {
            CheckZero(second);
            return first / second;
        }

        public override long Mod(long first, long second)
        {
            CheckZero(second);
            return first % second;
        }

        public override long Negate(long value) => -value;

        public override long Abs(long value) => Math.Abs(value);

        public override long Parse(string number) => long.Parse(number);

        public override long Value(int number) => number;
    }
}