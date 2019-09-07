using System.Collections.Generic;
using MeLanguage.Definer;
using MeLanguage.Parser.Tokenize;
using MeLanguage.Types.Exceptions;

namespace MeLanguage.Parser.Build
{
    public class TreeBuilder
    {
        public LanguageDefiner _definer;

        public TreeBuilder(LanguageDefiner definer)
        {
            _definer = definer;
        }

        public TokenNode MakeTree(Token[] postfix)
        {
            Stack<TokenNode> nodeStack = new Stack<TokenNode>();
            foreach (Token tok in postfix)
            {
                switch (tok.Type)
                {
                    case TokenType.LeftParen:
                        {
                            nodeStack.Push(new TokenNode(tok));
                            break;
                        }

                    case TokenType.Operator:
                        {
                            TokenNode node = new TokenNode(tok);
                            for (int i = 0; i < _definer.GetOperator(tok.Value).ParamCount; ++i)
                            {
                                if (nodeStack.Count == 0 || nodeStack.Peek().Token.Type == TokenType.LeftParen)
                                    throw new MeException("Parameter(s) missing for operator " + tok.Value + " .");
                                node.Parameters.Add(nodeStack.Pop());
                            }
                            nodeStack.Push(node);
                            node.Parameters.Reverse();
                            break;
                        }
                    case TokenType.Function:
                        {
                            TokenNode node = new TokenNode(tok);
                            while (nodeStack.Count != 0 && nodeStack.Peek().Token.Type != TokenType.LeftParen)
                            {
                                node.Parameters.Add(nodeStack.Pop());
                            }

                            if (nodeStack.Count == 0)
                            {
                                throw new MeException("No parenthesis found for function " + tok.Value + " .");
                            }
                            nodeStack.Pop();
                            node.Parameters.Reverse();
                            nodeStack.Push(node);
                            break;
                        }

                    case TokenType.Variable:
                        {
                            nodeStack.Push(new TokenNode(tok));
                            break;
                        }
                }
            }
            return nodeStack.Pop();
        }
    }
}