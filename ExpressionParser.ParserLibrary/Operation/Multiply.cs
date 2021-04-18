using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Умножение
    /// </summary>
    public class Multiply<T> : BinaryOperation<T>
    {
        /// <summary>
        /// Создание умножения
        /// </summary>
        public Multiply(IGenericExpression<T> first, IGenericExpression<T> second) : base(first, second)
        {
        }

        /// <summary>
        /// Вычисление произведения
        /// </summary>
        /// <returns>Произведение</returns>
        protected override T Calc(T first, T second, Mode<T> mode)
        {
            return mode.Multiply(first, second);
        }
    }
}