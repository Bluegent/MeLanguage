namespace MeLanguage.Definer.Operators.Mathematical
{
    using System;

    using MeLanguage.Types.Var;

    public class PowerOperator : IOperatorDefiner
    {
        public void AddOperator(LanguageDefiner definer)
        {
            Operator power =
                Utils.MakeOperator(LConstants.POWER_OP, 3, true,
                    (values, op) =>
                        {
                            op.CheckParamCount(values.Length);
                            MeNumber result = (float)Math.Pow(values[0].Get<float>(), values[1].Get<float>());
                            return result;
                        }, CommonValidators.TwoNumbers, CommonParamTypes.TwoNumbers);
            definer.AddOperator(power);
        }
    }
}