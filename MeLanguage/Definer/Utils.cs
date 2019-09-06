
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
    }

    public static class CommonParamTypes
    {
        public static readonly Type[] TwoNumbers = { typeof(MeNumber),typeof(MeNumber)};
        public static readonly Type[] Number = { typeof(MeNumber)};
        public static readonly Type[] Boolean = { typeof(MeBoolean) };
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
            Operator op = new Operator(character, precedence, leftAssoc, operatorTypes);
            op.OpFunc = operation;
            op.Validator = valid;
            return op;
        }

        public static Function MakeFunction(string name, Func<MeVariable[], Operation, MeVariable> operation, Type[] parameterTypes, bool[] executeInPlace = null)
        {
            Function func = new Function(name, parameterTypes, executeInPlace);
            func.OpFunc = operation;
            return func;
        }
    }
}