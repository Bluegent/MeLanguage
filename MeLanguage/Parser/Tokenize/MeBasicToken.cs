namespace MeLanguage.Parser.Tokenize
{
    public enum TokenType
    {
        Variable, LeftParen, RightParen, Separator, Function, Operator
    }
    public class MeBasicToken
    {

        public TokenType Type { get;  }
        public string Value { get;  }

        public MeBasicToken(string value, TokenType type)
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