using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpressionParser.ParserLibrary.Operation;

namespace ExpressionParser.ParserLibrary.Parser
{
    /// <summary>
    /// Парсер выражений
    /// </summary>
    /// <typeparam name="T">Тип вычислений</typeparam>
    public class ExpressionParser<T> : BaseParser
    {

        #region Приоритеты операций

        private static int NextPriority(int priority) => priority + 100;
        private const int MinPriority = 100;
        private static readonly int MultiplyPriority = NextPriority(MinPriority);
        private static readonly int ModPriority = NextPriority(MultiplyPriority);
        private static readonly int ConstPriority = NextPriority(ModPriority);

        #endregion

        /// <summary>
        /// Словарь списков строковых предствалений бинарных операций
        /// </summary>
        private static readonly Dictionary<int, List<string>> BinaryOperations = new Dictionary<int, List<string>>
        {
                {MinPriority, new List<string> {"+", "-"}},
                {MultiplyPriority, new List<string> {"*", "/"}},
                {ModPriority, new List<string> {"mod"}}
        };

        private delegate IGenericExpression<T>
                BinaryOperator(IGenericExpression<T> first, IGenericExpression<T> second);

        /// <summary>
        /// Словарь делегат бинарных операций
        /// </summary>
        private readonly Dictionary<string, BinaryOperator> _binaryGenerator = new Dictionary<string, BinaryOperator>
        {
                {"+", (first, second) => new Add<T>(first, second)},
                {"-", (first, second) => new Subtract<T>(first, second)},
                {"*", (first, second) => new Multiply<T>(first, second)},
                {"/", (first, second) => new Divide<T>(first, second)},
                {"mod", (first, second) => new Mod<T>(first, second)}
        };

        /// <summary>
        /// Парсить строку в математематическое выражение
        /// </summary>
        /// <param name="expression">Строковое представление математического выражения</param>
        /// <returns>Объектное представление математического выражения</returns>
        public IGenericExpression<T> Parse(string expression)
        {
            Source = new StringSource(expression);
            NextChar();
            var result = ParseOperation(MinPriority);
            return Eof() ? result : null;
        }

        private IGenericExpression<T> ParseOperation(int priority)
        {
            if (priority == ConstPriority)
            {
                return ParseUnaryOperation();
            }

            var result = ParseOperation(NextPriority(priority));
            while (true)
            {
                SkipWhitespaces();
                var currentOperation = FindOperation(priority);
                if (currentOperation == null)
                {
                    return result;
                }

                result = _binaryGenerator[currentOperation].Invoke(result, ParseOperation(NextPriority(priority)));
            }
        }

        private string FindOperation(int priority)
        {
            return BinaryOperations[priority].FirstOrDefault(Test);
        }

        private delegate IGenericExpression<T> UnaryOperator(IGenericExpression<T> value);

        private readonly Dictionary<string, UnaryOperator> _unaryGenerator = new Dictionary<string, UnaryOperator>()
        {
                {"abs", value => new Abs<T>(value)},
                {"square", value => new Square<T>(value)}
        };

        private IGenericExpression<T> ParseUnaryOperation()
        {
            SkipWhitespaces();
            if (Test('('))
            {
                var result = ParseOperation(MinPriority);
                return Test(')') ? result : null;
            }

            if (Test('-'))
            {
                return char.IsDigit(Current)
                        ? ParseConst(new StringBuilder("-"))
                        : new Negate<T>(ParseUnaryOperation());
            }

            if (char.IsDigit(Current))
            {
                return ParseConst(new StringBuilder());
            }

            var token = ParseStringUnaryOperation();
            return _unaryGenerator.ContainsKey(token)
                    ? _unaryGenerator[token].Invoke(ParseUnaryOperation())
                    : ParseVariable(token);
        }

        private string ParseStringUnaryOperation()
        {
            var sb = new StringBuilder();
            while (char.IsLetter(Current))
            {
                sb.Append(NextChar());
            }

            return sb.ToString();
        }

        private static IGenericExpression<T> ParseVariable(string variable)
        {
            switch (variable)
            {
                case "x":
                case "y":
                case "z":
                    return new Variable<T>(variable);
            }

            return null;
        }

        private IGenericExpression<T> ParseConst(StringBuilder sb)
        {
            if (!char.IsDigit(Current))
            {
                return null;
            }

            if (Test('0'))
            {
                sb.Append('0');
                if (char.IsDigit(Current))
                {
                    return null;
                }
            }

            CopyNumber(sb);
            return new Const<T>(sb.ToString());
        }

        private void CopyNumber(StringBuilder sb)
        {
            while (char.IsDigit(Current) || Check('.'))
            {
                sb.Append(NextChar());
            }
        }

        private void SkipWhitespaces()
        {
            while (Test(' ', '\n', '\r', '\t'))
            {
                // skip
            }
        }
    }
}