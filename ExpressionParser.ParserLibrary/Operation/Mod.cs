using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Остаток от деления
    /// </summary>
    public class Mod<T> : BinaryOperation<T>
    {
        /// <summary>
        /// Создание остатка от деления
        /// </summary>
        public Mod(IGenericExpression<T> first, IGenericExpression<T> second) : base(first, second)
        {
        }

        /// <summary>
        /// Вычисление остатка от деления
        /// </summary>
        /// <returns>Остаток от деления</returns>
        protected override T Calc(T first, T second, Mode<T> mode)
        {
            return mode.Mod(first, second);
        }
    }
}