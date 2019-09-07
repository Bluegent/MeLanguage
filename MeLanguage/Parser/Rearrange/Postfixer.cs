using System.Collections.Generic;
using MeLanguage.Definer;
using MeLanguage.Parser.Tokenize;
using MeLanguage.Types.Exceptions;

namespace MeLanguage.Parser.Rearrange
{
    public class Postfixer
    {
        private LanguageDefiner _definer;
        public Postfixer(LanguageDefiner definer)
        {
            _definer = definer;
        }

        private void ShuntOperators(List<Token> postfix, Stack<Token> opStack, Operator op)
        {
           

            Token nextTok = opStack.Count == 0 ? null : opStack.Peek();
            while (nextTok != null &&
                   nextTok.Type == TokenType.Operator &&
                   ((op.LeftAsoc && op.Precedence <= _definer.GetOperator(nextTok.Value).Precedence)
                    || (op.Precedence < _definer.GetOperator(nextTok.Value).Precedence))
            )
            {
                postfix.Add(opStack.Pop());
                nextTok = opStack.Count == 0 ? null : opStack.Peek();
            }
        }

        public Token[] ToPostfix(Token[] infix)
        {
            List<Token> postFix = new List<Token>();
            Stack<Token> opStack = new Stack<Token>();
            Token lastFunction = null;
            Token prevTok = null;

            foreach (Token tok in infix)
            {
                switch (tok.Type)
                {
                    case TokenType.Variable:
                        {
                            postFix.Add(tok);
                            break;
                        }
                    case TokenType.Function:
                        {
                            opStack.Push(tok);
                            lastFunction = tok;
                            break;
                        }

                    case TokenType.Separator:
                        {
                            if (prevTok != null && prevTok.Type == TokenType.Operator)
                                throw new MeException("Missing parameter(s) for operator " + prevTok.Value + " .");
                            while (opStack.Count != 0 && opStack.Peek().Type != TokenType.LeftParen)
                            {
                                postFix.Add(opStack.Pop());
                            }
                            if (opStack.Count == 0)
                            {
                                if (lastFunction == null)
                                {
                                    throw new MeException("Unexpected separator Key.");
                                }
                                throw new MeException("Found separator with no parameter preceding it for " + lastFunction.Value + " .");
                            }
                            break;
                        }

                    case TokenType.Operator:
                        {
                            if (prevTok != null && (prevTok.Type == TokenType.Separator || prevTok.Type == TokenType.LeftParen))
                            {
                                throw new MeException("Missing parameter(s) for operator " + tok.Value + " .");
                            }

                            Operator op = _definer.GetOperator(tok.Value);
                            ShuntOperators(postFix, opStack, op);
                            opStack.Push(tok);
                            break;
                        }
                    case TokenType.LeftParen:
                        {
                            if (prevTok != null && prevTok.Type == TokenType.Function)
                            {
                                postFix.Add(tok);
                            }
                            opStack.Push(tok);
                            break;
                        }
                    case TokenType.RightParen:
                        {
                            if (prevTok != null && prevTok.Type == TokenType.Operator)
                            {
                                throw new MeException("Missing parameter(s) for operator " + prevTok.Value + " .");
                            }
                            while (opStack.Count != 0 && opStack.Peek().Type != TokenType.LeftParen)
                            {
                                postFix.Add(opStack.Pop());
                            }
                            if (opStack.Count == 0)
                            {
                                if (prevTok != null)
                                    throw new MeException("Mismatched parenthesis after" + prevTok.Value + " .");
                            }
                            opStack.Pop();
                            if (opStack.Count != 0 && opStack.Peek().Type == TokenType.Function)
                            {
                                postFix.Add(opStack.Pop());
                            }
                            break;
                        }

                }
                prevTok = tok;
            }
            while (opStack.Count != 0)
            {
                Token tok = opStack.Pop();
                if (tok.Type == TokenType.LeftParen || tok.Type == TokenType.RightParen)
                    if (prevTok != null) throw new MeException("Mismatched parenthesis after" + prevTok.Value + " .");
                postFix.Add(tok);
            }
            return postFix.ToArray();
        }
    }
}
