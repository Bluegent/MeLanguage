using System;
using MeLanguage.Types.Var;

namespace MeLanguage.Types.Exceptions
{
    public class MeInvalidCastException : MeException
    {
        public MeInvalidCastException(MeVariable var, Type t)
            : base($"Invalid cast of {var}({var.GetType().Name}) to {t.Name}")
        {
        }
    }
}