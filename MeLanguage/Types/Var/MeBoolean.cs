namespace MeLanguage.Types.Var
{
    using System;

    public class MeBoolean : MeVariable
    {
        public MeBoolean(bool obj)
            : base(obj)
        {
        }

        public static implicit operator MeBoolean(bool value)
        {
            return new MeBoolean(value);
        }

        public override T Get<T>()
        {
            Type tType = typeof(T);
            if (tType == typeof(bool))
            {
                return (T)Convert.ChangeType(_value, tType);
            }

            throw CastExcept(tType);
        }
        
        public override string ToString()
        {
            return $"{MeMarkers.BOOL_MARKER}{_value}";
        }
    }
}