
namespace MeLanguage.Definer
{
    using System;

    using MeLanguage.Types.Var;

    public  interface IOperatorDefiner
    {
        void AddOperator(LanguageDefiner definer);
    }

    public interface IFunctionDefiner
    {
        void AddFunction(LanguageDefiner definer);
    }

    public static class CommonValidators
    {
        public static readonly Validator TwoNumbers = new Validator(
            (values, op) =>
                {
                    values[0].Get<float>();
                    values[1].Get<float>();
                    return true;
                });
        public static readonly Validator TwoStrings = new Validator(
            (values, op) =>
                {
                    values[0].Get<string>();
                    values[1].Get<string>();
                    return true;
                });
    }

    public static class CommonParamTypes
    {
        public static readonly Type[] TwoNumbers = { typeof(MeNumber),typeof(MeNumber)};
        public static readonly Type[] SingleNumber = { typeof(MeNumber)};
        public static readonly Type[] SingleBoolean = { typeof(MeBoolean) };
        public static readonly Type[] TwoStrings = { typeof(MeString), typeof(MeString) };
        public static readonly Type[] SingleString = { typeof(MeString) };
    }


    public class Utils
    {
        public static Operator MakeOperator(
            string character,
            int precedence,
            bool leftAssoc,
            Func<MeVariable[], Operation, MeVariable> operation,
            Validator valid,
            Type[] operatorTypes)
        {
            Operator op = new Operator(character, precedence, leftAssoc,operation, operatorTypes);
            op.Validator = valid;
            return op;
        }

        public static Function MakeFunction(string name, Func<MeVariable[], Operation, MeVariable> operation, Type[] parameterTypes, bool hasParamCount = true, bool[] executeInPlace = null)
        {
            Function func = new Function(name,  operation, parameterTypes, hasParamCount, executeInPlace);
            return func;
        }
    }
}