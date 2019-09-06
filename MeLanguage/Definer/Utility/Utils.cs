
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

        public static Function MakeFunction(string name, Func<MeVariable[], Operation, MeVariable> operation, Type[] parameterTypes,Validator validator, bool hasParamCount = true, bool[] executeInPlace = null)
        {
            Function func = new Function(name,  operation, parameterTypes, hasParamCount, executeInPlace);
            func.Validator = validator;
            return func;
        }
    }
}