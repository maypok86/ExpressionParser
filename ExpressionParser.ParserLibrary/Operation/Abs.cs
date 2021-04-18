using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Модуль
    /// </summary>
    public class Abs<T> : UnaryOperation<T>
    {
        /// <summary>
        /// Создание модуля
        /// </summary>
        public Abs(IGenericExpression<T> value) : base(value)
        {
        }

        /// <summary>
        /// Вычисление значения модуля
        /// </summary>
        /// <returns>Модуль</returns>
        protected override T Calc(T value, Mode<T> mode)
        {
            return mode.Abs(value);
        }
    }
}