using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Вычитание
    /// </summary>
    public class Subtract<T> : BinaryOperation<T>
    {
        /// <summary>
        /// Создание вычитания
        /// </summary>
        public Subtract(IGenericExpression<T> first, IGenericExpression<T> second) : base(first, second)
        {
        }

        /// <summary>
        /// Вычисление разности
        /// </summary>
        /// <returns>Разность</returns>
        protected override T Calc(T first, T second, Mode<T> mode)
        {
            return mode.Subtract(first, second);
        }
    }
}