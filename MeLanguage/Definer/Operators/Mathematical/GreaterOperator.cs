namespace MeLanguage.Definer.Operators.Mathematical
{
    using MeLanguage.Types.Var;

    public class GreaterOperator : IOperatorDefiner
    {
        public Operator DefineOperator()
        {
            return Utils.MakeOperator(LConstants.GREATER_OP, 0, true,
                (values, op) =>
                    {
                        op.CheckParamCount(values.Length);
                        MeBoolean value = values[0].Get<float>() > values[1].Get<float>();
                        return value;
                    }, CommonValidators.TwoNumbers);
        }
    }
}