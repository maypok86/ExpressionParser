using System;

namespace ExpressionParser.ParserLibrary.Mode
{
    /// <summary>
    /// Режим вычислений
    /// </summary>
    /// <typeparam name="T">Тип вычислений</typeparam>
    public abstract class Mode<T>
    {
        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="first">Первый аргумент</param>
        /// <param name="second">Второй аргумент</param>
        /// <returns>Сумма</returns>
        public abstract T Add(T first, T second);
        /// <summary>
        /// Вычитание
        /// </summary>
        /// <param name="first">Первый аргумент</param>
        /// <param name="second">Второй аргумент</param>
        /// <returns>Разность</returns>
        public abstract T Subtract(T first, T second);
        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="first">Первый аргумент</param>
        /// <param name="second">Второй аргумент</param>
        /// <returns>ПРоизведение</returns>
        public abstract T Multiply(T first, T second);
        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="first">Первый аргумент</param>
        /// <param name="second">Второй аргумент</param>
        /// <returns>Частное</returns>
        public abstract T Divide(T first, T second);
        /// <summary>
        /// Остаток от деления
        /// </summary>
        /// <param name="first">Первый аргумент</param>
        /// <param name="second">Второй аргумент</param>
        /// <returns>Остаток от деление first на second</returns>
        public abstract T Mod(T first, T second);
        /// <summary>
        /// Унарный минус
        /// </summary>
        /// <param name="value">Аргумент</param>
        /// <returns>Отрицание</returns>
        public abstract T Negate(T value);
        /// <summary>
        /// Модуль
        /// </summary>
        /// <param name="value">Аргумент</param>
        /// <returns>Модуль</returns>
        public abstract T Abs(T value);
        /// <summary>
        /// Возведение в квадрат
        /// </summary>
        /// <param name="value">Аргумент</param>
        /// <returns>Квадрат</returns>
        public T Square(T value) => Multiply(value, value);
        /// <summary>
        /// Парсинг
        /// </summary>
        /// <param name="number">Стрококовое представление числа</param>
        /// <returns>Разобранное значение</returns>
        public abstract T Parse(string number);
        /// <summary>
        /// Каст числа в нужный тип
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Переведённое в нужный тип число</returns>
        public abstract T Value(int number);
    }
}