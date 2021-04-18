using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Унарный минус
    /// </summary>
    public class Negate<T> : UnaryOperation<T>
    {
        /// <summary>
        /// Создание унарного минуса
        /// </summary>
        public Negate(IGenericExpression<T> value) : base(value)
        {
        }

        /// <summary>
        /// Вычисление значения отрицания
        /// </summary>
        /// <returns>Отрицание</returns>
        protected override T Calc(T value, Mode<T> mode)
        {
            return mode.Negate(value);
        }
    }
}