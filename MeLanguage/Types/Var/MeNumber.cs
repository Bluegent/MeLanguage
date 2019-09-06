using System;

using Language.Types.Var;

namespace Language.Types.Var
{
    public class MeNumber : MeVariable
    {

        public override T Get<T>()
        {
            Type tType = typeof(T);
            if (tType == typeof(int) || tType == typeof(float) || tType == typeof(long))
                return (T)Convert.ChangeType(_value, typeof(T));
            throw Except(typeof(T));

        }

        public override string ToString()
        {
            return _value.ToString();
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