namespace MeLanguage.Definer
{
    using System.Collections.Generic;

    using MeLanguage.Types.Var;

    public class LanguageDefiner
    {
        public Dictionary<Function,Dictionary<int,Function>> Functions;
        public Dictionary<Function, Dictionary<int, Operator>> Operators;

        public LanguageDefiner()
        {
            Functions = new Dictionary<Function, Dictionary<int, Function>>();
            Operators = new Dictionary<Function, Dictionary<int, Operator>>();
        }
    }
}