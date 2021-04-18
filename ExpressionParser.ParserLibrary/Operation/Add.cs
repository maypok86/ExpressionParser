using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Сложение
    /// </summary>
    public class Add<T> : BinaryOperation<T>
    {
        /// <summary>
        /// Создание сложения
        /// </summary>
        public Add(IGenericExpression<T> first, IGenericExpression<T> second) : base(first, second)
        {
        }

        /// <summary>
        /// Вычисление суммы
        /// </summary>
        /// <returns>Сумма</returns>
        protected override T Calc(T first, T second, Mode<T> mode)
        {
            return mode.Add(first, second);
        }
    }
}