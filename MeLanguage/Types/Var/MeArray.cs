namespace MeLanguage.Types.Var
{
    using System;
    using System.Text;

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