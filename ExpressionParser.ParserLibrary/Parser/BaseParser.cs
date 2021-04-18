using System.Collections.Generic;
using System.Linq;

namespace ExpressionParser.ParserLibrary.Parser
{
    /// <summary>
    /// Базовый парсер
    /// </summary>
    public class BaseParser
    {
        /// <summary>
        /// Конец ресурса
        /// </summary>
        private const char End = '\0';
        /// <summary>
        /// Источник символов
        /// </summary>
        protected ICharSource Source { get; set; }
        /// <summary>
        /// Текущий символ
        /// </summary>
        protected char Current { get; private set; } = (char) 0xffff;

        /// <summary>
        /// Перейти на следующий символ
        /// </summary>
        /// <returns>Предыдущий символ</returns>
        protected char NextChar()
        {
            var res = Current;
            if (Source.HasNext)
            {
                Current = Source.Next;
                return res;
            }

            Current = End;
            return res;
        }

        /// <summary>
        /// Равен ли текущий символ одному из переданных, если да, то перейти на следующий
        /// </summary>
        /// <param name="chars">Массив символов</param>
        /// <returns>Результат проверки</returns>
        protected bool Test(params char[] chars)
        {
            if (chars.All(c => Current != c)) return false;
            NextChar();
            return true;
        }

        /// <summary>
        /// Содержит ли источник переданную строку, если да, то пропустить её
        /// </summary>
        /// <param name="expected">Проверяемая строка</param>
        /// <returns>Результат проверки</returns>
        protected bool Test(string expected)
        {
            return expected.All(c => Test(c));
        }
        
        /// <summary>
        /// Проверить Check(string) все строки из коллекции
        /// </summary>
        /// <param name="list">Коллекция проверяемых строк</param>
        /// <returns>Результат проверки</returns>
        protected bool Check(IEnumerable<string> list)
        {
            return list.Any(letters => Source.Check(letters));
        }

        /// <summary>
        /// Содержит ли ресурс стрроку
        /// </summary>
        /// <param name="letters">Проверяемая строка</param>
        /// <returns>Результат проверки</returns>
        protected bool Check(string letters) => Source.Check(letters);
       
        /// <summary>
        /// Равен ли текущий символ какому-либо сиволу из массива
        /// </summary>
        /// <param name="chars">массив символов</param>
        /// <returns>Результат проверки</returns>
        protected bool Check(params char[] chars)
        {
            return chars.Aggregate(false, (current, c) => current | (Current == c));
        }

        /// <summary>
        /// Закончился ли ресурс
        /// </summary>
        /// <returns>Результат проверки</returns>
        protected bool Eof() => Check(End);
    }
}