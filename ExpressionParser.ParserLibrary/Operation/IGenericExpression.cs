using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Разобранное математическое выражение
    /// </summary>
    /// <typeparam name="T">Тип вычислений</typeparam>
    public interface IGenericExpression<T>
    {
        /// <summary>
        /// Вычисление математического выражения
        /// </summary>
        /// <param name="x">Значение переменной x</param>
        /// <param name="y">Значение переменной y</param>
        /// <param name="z">Значение переменной z</param>
        /// <param name="mode">Режим вычислений</param>
        /// <returns>Результат вычисления</returns>
        T Evaluate(T x, T y, T z, Mode<T> mode);
    }
}