namespace MeLanguage.Utility
{
    using System;

    public class MathUtils
    {
        public static bool DoubleEq(double a, double b)
        {
            return Math.Abs(a - b) < 0.0000000000001;
        }
    }
}