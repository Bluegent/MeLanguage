using System;

using MeLanguage.Types.Var;

namespace MeLanguage.Types.Var
{
    public class MeNumber : MeVariable
    {

        public override T Get<T>()
        {
            Type tType = typeof(T);
            if (tType == typeof(int) || tType == typeof(float) || tType == typeof(long))
                return (T)Convert.ChangeType(_value, typeof(T));
            throw CastExcept(typeof(T));

        }

        public static implicit operator MeNumber(float value)
        {
            return  new MeNumber(value);
        }

        public static implicit operator MeNumber(int value)
        {
            return new MeNumber(value);
        }

        public static implicit operator MeNumber(long value)
        {
            return new MeNumber(value);
        }

        public override string ToString()
        {
            return $"{MeMarkers.NUMBER_MARKER}{_value}";
        }

        public MeNumber(float obj)
            : base(obj)
        {
        }

        public MeNumber(int obj)
            : base(obj)
        {
        }

        public MeNumber(long obj)
            : base(obj)
        {
        }

    }
}