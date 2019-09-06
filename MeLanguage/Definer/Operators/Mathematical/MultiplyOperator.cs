namespace MeLanguage.Definer.Operators.Mathematical
{
    using MeLanguage.Types.Var;

    public class MultiplyOperator : IOperatorDefiner
    {

        public void AddOperator(LanguageDefiner definer)
        {
            Operator multiply = Utils.MakeOperator(LConstants.MULITPLY_OP, 2, true,
                (values, op) =>
                    {
                        op.CheckParamCount(values.Length);
                        MeNumber result = values[0].Get<float>() * values[1].Get<float>();
                        return result;
                    }, CommonValidators.TwoNumbers, CommonParamTypes.TwoNumbers);
            definer.AddOperator(multiply);
        }
    }
}