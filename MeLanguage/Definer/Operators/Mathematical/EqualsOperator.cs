namespace MeLanguage.Definer.Operators.Mathematical
{
    using System.Security.Claims;

    using MeLanguage.Types.Var;
    using MeLanguage.Utility;

    public class EqualsOperator : IOperatorDefiner
    {
        public void AddOperator(LanguageDefiner definer)
        {
            Operator numEq = Utils.MakeOperator(LConstants.EQUAL_OP, 0, true,
                (values, op) =>
                    {
                        op.CheckParamCount(values.Length);
                        MeBoolean value = MathUtils.DoubleEq(values[0].Get<float>(), values[1].Get<float>());
                        return value;
                    }, CommonValidators.TwoNumbers, CommonParamTypes.TwoNumbers);

            Operator stringEq = Utils.MakeOperator(LConstants.EQUAL_OP, 0, true,
                (values, op) =>
                    {
                        op.CheckParamCount(values.Length);
                        MeBoolean value = values[0].Get<string>().Equals(values[1].Get<string>());
                        return value;
                    }, CommonValidators.TwoStrings, CommonParamTypes.TwoStrings);
            definer.AddOperator(numEq);
            definer.AddOperator(stringEq);
        }
    }
}