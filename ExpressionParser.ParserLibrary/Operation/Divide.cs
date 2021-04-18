using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Деление
    /// </summary>
    public class Divide<T> : BinaryOperation<T>
    {
        /// <summary>
        /// Создание деления
        /// </summary>
        public Divide(IGenericExpression<T> first, IGenericExpression<T> second) : base(first, second)
        {
        }

        /// <summary>
        /// Вычисление частного
        /// </summary>
        /// <returns>Частное</returns>
        protected override T Calc(T first, T second, Mode<T> mode)
        {
            return mode.Divide(first, second);
        }
    }
}