using System;
using MeLanguage.Types.Exceptions;
using MeLanguage.Types.Var;

namespace MeLanguage.Definer
{
    using MeLanguage.Types.Exceptions;
    using MeLanguage.Types.Var;

    public class Validator
    {
        private Func<MeVariable[], Operation, bool> Func { get; set; }

        public static implicit operator Validator(Func<MeVariable[], Operation, bool> func)
        {
            return new Validator(func);
        }

        public Validator(Func<MeVariable[], Operation, bool> func)
        {
            Func = func;
        }

        public bool Validate(MeVariable[] values, Operation op)
        {
            try
            {
                return Func.Invoke(values, op);
            }
            catch (MeException)
            {
                return false;
            }
        }
    }

}