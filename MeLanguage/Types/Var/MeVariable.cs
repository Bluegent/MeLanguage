
using System;
using MeLanguage.Types.Exceptions;
namespace MeLanguage.Types.Var
{


    public abstract class MeVariable
    {
        protected object _value;
        public Type Type { get; }
        protected MeVariable(object obj)
        {
            _value = obj;
            Type = obj.GetType();
        }

        protected MeInvalidCastException CastExcept(Type t)
        {
            return new MeInvalidCastException(this, t);
        }
        public abstract T Get<T>();

        public abstract override string ToString();
    }

}
