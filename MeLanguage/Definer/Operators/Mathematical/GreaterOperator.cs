using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Operators.Mathematical
{
    using Types.Var;

    public class GreaterOperator : IOperatorDefiner
    {
        public Operator Greater { get; }

        public GreaterOperator()
        {
            Greater = Utils.MakeOperator(LConstants.GREATER_OP, 0, true,
                (values, op) =>
                {
                    op.CheckParamCount(values.Length);
                    MeBoolean value = values[0].Get<float>() > values[1].Get<float>();
                    return value;
                }, CommonValidators.TwoNumbers, CommonParamTypes.TwoNumbers);
        }

        public void AddOperator(LanguageDefiner definer)
        {
            definer.AddOperator(Greater);
        }
    }
}