namespace ExpressionParser.ParserLibrary.Parser
{
    /// <summary>
    /// Источник символов
    /// </summary>
    public interface ICharSource
    {
        /// <summary>
        /// Есть ли ещё символы
        /// </summary>
        bool HasNext { get; }
        /// <summary>
        /// Перейти на следующий символ
        /// </summary>
        char Next { get; }
        /// <summary>
        /// Текущий символ
        /// </summary>
        char Current { get; }
        /// <summary>
        /// Проверить, идёт ли в источнике далее подстрока letters 
        /// </summary>
        /// <param name="letters">Подстрока</param>
        /// <returns>Идёт ли в источнике далее подстрока letters </returns>
        bool Check(string letters);
        /// <summary>
        /// Проверить равен ли текущий символ, переданному
        /// </summary>
        /// <param name="symbol">Проверяемый символ</param>
        /// <returns>Равен ли текущий символ переданному</returns>
        bool Check(char symbol);

        /// <summary>
        /// Количество символов в истотчнике
        /// </summary>
        int Length { get; }
        /// <summary>
        /// Позиция в источнике
        /// </summary>
        int Position { get; }
    }
}