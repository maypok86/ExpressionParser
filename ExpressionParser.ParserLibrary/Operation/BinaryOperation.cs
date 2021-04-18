using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Бинарная операция
    /// </summary>
    /// <typeparam name="T">Тип вычислений</typeparam>
    public abstract class BinaryOperation<T> : IGenericExpression<T>
    {
        private readonly IGenericExpression<T> _first;
        private readonly IGenericExpression<T> _second;

        /// <summary>
        /// Создание бинарной операции
        /// </summary>
        /// <param name="first">Первый аргумент</param>
        /// <param name="second">Второй аргумент</param>
        protected BinaryOperation(IGenericExpression<T> first, IGenericExpression<T> second)
        {
            _first = first;
            _second = second;
        }

        /// <summary>
        /// Вычисление значение бинарной операции
        /// </summary>
        /// <returns>Значение бинарной операции</returns>
        public T Evaluate(T x, T y, T z, Mode<T> mode)
        {
            return Calc(_first.Evaluate(x, y, z, mode), _second.Evaluate(x, y, z, mode), mode);
        }

        protected abstract T Calc(T first, T second, Mode<T> mode);
    }
}