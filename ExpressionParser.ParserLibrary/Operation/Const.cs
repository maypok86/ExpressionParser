using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Константа
    /// </summary>
    /// <typeparam name="T">Тип вычислений</typeparam>
    public class Const<T> : IGenericExpression<T>
    {
        private readonly string _value;

        /// <summary>
        /// Создание константы
        /// </summary>
        /// <param name="value">Значение константы</param>
        public Const(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Вычисление значения константы
        /// </summary>
        /// <returns>Значение константы</returns>
        public T Evaluate(T x, T y, T z, Mode<T> mode)
        {
            return mode.Parse(_value);
        }
    }
}