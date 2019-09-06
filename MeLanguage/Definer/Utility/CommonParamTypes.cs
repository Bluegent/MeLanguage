using System;
using MeLanguage.Types.Var;

namespace MeLanguage.Definer.Utility
{
    public static class CommonParamTypes
    {
        public static readonly Type[] TwoNumbers = { typeof(MeNumber),typeof(MeNumber)};
        public static readonly Type[] SingleNumber = { typeof(MeNumber)};
        public static readonly Type[] SingleBoolean = { typeof(MeBoolean) };
        public static readonly Type[] TwoStrings = { typeof(MeString), typeof(MeString) };
        public static readonly Type[] SingleString = { typeof(MeString) };
    }
}