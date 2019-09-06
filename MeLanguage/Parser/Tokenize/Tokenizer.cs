using System.Configuration;

namespace MeLanguage.Parser.Tokenize
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Tokenizer
    {

        public static MeBasicToken[] Tokenize(string expression)
        {
            List<MeBasicToken> result = new List<MeBasicToken>();
            string current = "";
            bool inString = false;
            int i = 0;
            while (i < expression.Length)
            {
                /*
                char c = expression[i];
                if (c == '"')
                {
                    if (inString)
                    {
                        MeBasicToken stringToken = new MeBasicToken(current);
                        result.Add(stringToken);
                        current = "";
                    }
                    inString = !inString;

                }
                else if (inString)
                {
                    current += c;
                }
                else if (Definer.Instance().Ignore(c))
                {

                }
                else if (!Definer.Instance().IsSpecialChar(c))
                {
                    current += c;
                }
                else if (c == '-')
                {
                    if (current.Length != 0)
                    {
                        Token testToken = new Token(current);
                        if (testToken.Type == TokenType.Variable)
                        {
                            result.Add(testToken);
                            current = "";
                        }
                    }

                    if (result.Count == 0)
                    {
                        current = "-";
                    }
                    else
                    {
                        Token prev = result.Last();
                        switch (prev.Type)
                        {
                            case TokenType.Function:
                                throw new Exception(
                                    $"Found minus after function with no (, function:\"{prev.Value}\".");
                            case TokenType.Variable:
                            case TokenType.RightParen:
                                result.Add(new Token(char.ToString(c)));
                                break;
                            default:
                                current = "-";
                                break;
                        }
                    }

                    //eventually consider -=
                }
                else
                {
                    if (current.Length != 0)
                    {
                        result.Add(new Token(current));
                        current = "";
                    }
                    if (i < expression.Length - 1 && Definer.Instance().IsOperatorChar(c) && Definer.Instance().IsOperatorChar(expression[i + 1]))
                    {
                        string possibleOp = char.ToString(c) + expression[i + 1];
                        if (Definer.Instance().IsOperator(possibleOp))
                        {
                            result.Add(new Token(possibleOp));
                            ++i;
                        }
                    }
                    else
                    {
                        result.Add(new Token(char.ToString(c)));
                    }

                }
                 */
                ++i;
            }
           /* if (current.Length != 0)
                result.Add(new MeBasicToken(current));
               */
            return result.ToArray();
        }
    }
}
