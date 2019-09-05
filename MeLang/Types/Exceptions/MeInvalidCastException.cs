using System;

using Language.Types.Exceptions;
using Language.Types.Var;

public class MeInvalidCastException : MeException
{
    public MeInvalidCastException(MeVariable var, Type t)
        : base($"Invalid cast of {var}({var.Type}) to {t.ToString()}.")
    {
    }
}