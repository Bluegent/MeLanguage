using MeLanguage.Definer;
using MeLanguage.Parser.Rearrange;
using MeLanguage.Parser.Tokenize;

namespace MeLanguage.Parser
{
    public class MeParser
    {
        public Tokenizer Tokenizer { get; }
        public Postfixer Postfixer { get; }

        public MeParser(LanguageDefiner definer)
        {
            Tokenizer = new Tokenizer(definer);
            Postfixer = new Postfixer(definer);
        }

        public Token[] ToPostfix(string expression)
        {
            Token[] infix = Tokenizer.Tokenize(expression);
            return Postfixer.ToPostfix(infix);
        }

    }
}
