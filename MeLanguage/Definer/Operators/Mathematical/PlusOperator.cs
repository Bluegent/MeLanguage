
using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Operators.Mathematical
{
    using MeLanguage.Types.Var;

    public class PlusOperator : IOperatorDefiner
    {
        public Operator Plus;

        public PlusOperator()
        {
            Plus = Utils.MakeOperator(
                LConstants.PLUS_OP,
                1,
                true,
                (values, op) =>
                {
                    op.CheckParamCount(values.Length);
                    MeNumber result = values[0].Get<float>() + values[1].Get<float>();
                    return result;
                }, CommonValidators.TwoNumbers, CommonParamTypes.TwoNumbers);
        }
        
        public void AddOperator(LanguageDefiner definer)
        {
            definer.AddOperator(Plus);
        }
    }
}