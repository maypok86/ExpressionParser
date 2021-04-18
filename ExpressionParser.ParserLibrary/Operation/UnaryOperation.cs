using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Унарная операция
    /// </summary>
    /// <typeparam name="T">Тип вычислений</typeparam>
    public abstract class UnaryOperation<T> : IGenericExpression<T>
    {
        private readonly IGenericExpression<T> _value;

        /// <summary>
        /// Создание унарной операции
        /// </summary>
        /// <param name="value">Аргумент</param>
        protected UnaryOperation(IGenericExpression<T> value)
        {
            _value = value;
        }

        /// <summary>
        /// Вычисление значения унарной операции
        /// </summary>
        /// <returns>Значение унарной операции</returns>
        public T Evaluate(T x, T y, T z, Mode<T> mode)
        {
            return Calc(_value.Evaluate(x, y, z, mode), mode);
        }
        
        protected abstract T Calc(T value, Mode<T> mode);
    }
}