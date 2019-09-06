using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Operators.Mathematical
{
    using MeLanguage.Types.Var;
    public class MinusOperator :IOperatorDefiner
    {
        public Operator Minus;

        public MinusOperator()
        {
            Minus = Utils.MakeOperator(LConstants.MINUS_OP, 1, true,
                (values, op) =>
                {
                    op.CheckParamCount(values.Length);
                    MeNumber result = values[0].Get<float>() - values[1].Get<float>();
                    return result;
                }, CommonValidators.TwoNumbers, CommonParamTypes.TwoNumbers);
        }
        public void AddOperator(LanguageDefiner definer)
        {
            definer.AddOperator(Minus);
        }
    }
}