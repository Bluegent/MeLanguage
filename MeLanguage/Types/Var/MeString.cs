namespace MeLanguage.Types.Var
{
    using System;

    public class MeString : MeVariable
    {
        public MeString(string obj)
            : base(obj)
        {
        }

        public override T Get<T>()
        {
            Type tType = typeof(T);
            if (tType == typeof(string))
                return (T)Convert.ChangeType(_value, tType);
            throw CastExcept(tType);
        }

        public override string ToString()
        {
            return (string)_value;
        }

        public static implicit operator MeString(string str)
        {
            return new MeString(str);
        }
    }
}