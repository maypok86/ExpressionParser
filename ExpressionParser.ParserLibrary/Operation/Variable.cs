using System;
using ExpressionParser.ParserLibrary.Mode;

namespace ExpressionParser.ParserLibrary.Operation
{
    /// <summary>
    /// Переменная
    /// </summary>
    /// <typeparam name="T">Тип вычислений</typeparam>
    public class Variable<T> : IGenericExpression<T>
    {
        private readonly string _name;

        /// <summary>
        /// Создание переменной
        /// </summary>
        /// <param name="name">Имя переменной</param>
        public Variable(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Вычисление значения переменной
        /// </summary>
        /// <returns>Значение переменной</returns>
        /// <exception cref="Exception"></exception>
        public T Evaluate(T x, T y, T z, Mode<T> mode)
        {
            return _name switch
            {
                    "x" => x,
                    "y" => y,
                    "z" => z,
                    _ => throw new Exception()
            };
        }
    }
}