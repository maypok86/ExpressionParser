using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Квадрат
    /// </summary>
    public class Square<T> : UnaryOperation<T>
    {
        /// <summary>
        /// Создание квадрата
        /// </summary>
        public Square(IGenericExpression<T> value) : base(value)
        {
        }

        /// <summary>
        /// Возведение в квадрат
        /// </summary>
        /// <returns>Квадрат</returns>
        protected override T Calc(T value, Mode<T> mode)
        {
            return mode.Square(value);
        }
    }
}