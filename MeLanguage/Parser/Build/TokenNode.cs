using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using MeLanguage.Parser.Tokenize;

namespace MeLanguage.Parser.Build
{
    public class TokenNode
    {
        public Token Token { get; }
        public List<TokenNode> Parameters { get; }

        public TokenNode(Token token)
        {
            Token = token;
            Parameters = new List<TokenNode>();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(Token.Value);
            builder.Append("[");
            if (Parameters.Count != 0)
            {
                foreach (TokenNode node in Parameters)
                {
                    builder.Append(node);
                    builder.Append(", ");
                }
                builder.Remove(builder.Length - 2, 2);
            }
            return builder.ToString();
        }
    }
}