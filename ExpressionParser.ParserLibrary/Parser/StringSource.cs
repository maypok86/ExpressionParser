namespace ExpressionParser.ParserLibrary.Parser
{
    /// <summary>
    /// Строковый ресурс
    /// </summary>
    public class StringSource : ICharSource
    {
        private readonly string _data;

        /// <summary>
        /// Создание строкового ресурса
        /// </summary>
        /// <param name="data">Строка-источник</param>
        public StringSource(string data)
        {
            _data = data;
        }
        
        public int Position { get; private set; } = 0;

        public int Length => _data.Length;

        public bool HasNext => Position < _data.Length;

        public char Next => _data[Position++];

        public char Current => _data[Position];

        public bool Check(string letters)
        {
            return Length >= Position - 1 + letters.Length && 
                   letters.Equals(_data.Substring(Position - 1, letters.Length));
        }

        public bool Check(char symbol) => symbol == Current;
    }
}