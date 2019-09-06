namespace MeLanguage.Parser.Tokenize
{
    public enum TokenType
    {
        Variable, LeftParen, RightParen, Separator, Function, Operator
    }
    public class Token
    {

        public TokenType Type { get;  }
        public string Value { get;  }

        public Token(string value, TokenType type)
        {
            Value = value;
            Type = type;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}