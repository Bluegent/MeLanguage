
namespace MeLanguage.Parser.Tokenize
{
    using Definer;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tokenizer
    {
        private LanguageDefiner _definer;
        public Tokenizer(LanguageDefiner definer)
        {
            _definer = definer;
        }

        public TokenType GetType(string str)
        {
            if (_definer.IsFunction(str))
                return TokenType.Function;
            if (_definer.IsOperator(str))
                return TokenType.Operator;
            if (_definer.IsLeftParen(str))
                return TokenType.LeftParen;
            if (_definer.IsRightParen(str))
                return TokenType.RightParen;
            if (_definer.IsSeparator(str))
                return TokenType.Separator;
            return TokenType.Variable;

        }


        public Token CreateToken(string tokenString)
        {
            return new Token(tokenString, GetType(tokenString));
        }

        public Token CreateToken(char c)
        {
            string charString = char.ToString(c);
            return new Token(charString, GetType(charString));
        }

        public Token[] Tokenize(string expression)
        {
            List<Token> result = new List<Token>();
            string current = "";
            bool inString = false;
            int i = 0;
            while (i < expression.Length)
            {

                char c = expression[i];
                if (c == '"')
                {
                    if (inString)
                    {
                        Token stringToken = CreateToken(current);
                        result.Add(stringToken);
                        current = "";
                    }
                    inString = !inString;

                }
                else if (inString)
                {
                    current += c;
                }
                else if (_definer.IsIgnored(c))
                {

                }
                else if (!_definer.IsSpecialChar(c))
                {
                    current += c;
                }
                else if (c == '-')
                {
                    if (current.Length != 0)
                    {
                        Token testToken = CreateToken(current);
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
                                result.Add(CreateToken(c));
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
                        result.Add(CreateToken(c));
                        current = "";
                    }
                    if (i < expression.Length - 1 && _definer.IsOperatorCharacter(c) && _definer.IsOperatorCharacter(expression[i + 1]))
                    {
                        string possibleOp = char.ToString(c) + expression[i + 1];
                        if (_definer.IsOperator(possibleOp))
                        {
                            result.Add(CreateToken(possibleOp));
                            ++i;
                        }
                    }
                    else
                    {
                        result.Add(CreateToken(c));
                    }

                }

                ++i;
            }
            if (current.Length != 0)
                result.Add(CreateToken(current));

            return result.ToArray();
        }
    }
}
