namespace MeLanguage.Types.Var
{
    using System;
    using System.Text;

    using MeLanguage.Utility;

    public class MeArray : MeVariable
    {
        public MeArray(MeVariable[] obj)
            : base(obj)
        {
        }

        public override T Get<T>()
        {
            Type tType = typeof(T);

            if (tType == typeof(MeVariable[]))
            {
                return (T)Convert.ChangeType(_value, tType);
            }
            throw CastExcept(tType);
        }

        public static float[] ToFloatArray(MeVariable[] arr)
        {
            float[] numArr = new float[arr.Length];
            for (int index = 0; index < arr.Length; ++index)
            {
                numArr[index] = arr[index].Get<float>();
            }

            return numArr;
        }


        public static int GetTypeHashCode(MeVariable[] arr)
        {
            int hash = GlobalConstants.HASH_BASE;
            foreach (MeVariable var in arr)
            {
                hash = hash * GlobalConstants.HASH_MULTIPLIER + var.GetType().GetHashCode();
            }
            return hash;
        }

        public static int GetHashCode(Type[] arr)
        {
            int hash = GlobalConstants.HASH_BASE;
            foreach (Type var in arr)
            {
                hash = hash * GlobalConstants.HASH_MULTIPLIER + var.GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            MeVariable[] arr = Get<MeVariable[]>();
            StringBuilder builder = new StringBuilder(MeMarkers.ARRAY_MARKER);
            builder.Append("[");
            if (arr.Length != 0)
            {
                foreach (MeVariable var in arr)
                {
                    builder.Append(var.ToString());
                    builder.Append(", ");
                }
            }
            builder.Append("]");

            return builder.ToString();
        }
    }
}