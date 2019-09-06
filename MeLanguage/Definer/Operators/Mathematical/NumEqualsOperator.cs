﻿namespace MeLanguage.Definer.Operators.Mathematical
{
    using System.Security.Claims;

    using MeLanguage.Types.Var;
    using MeLanguage.Utility;

    public class NumEqualsOperator : IOperatorDefiner
    {
        public Operator DefineOperator()
        {

            return Utils.MakeOperator(LConstants.EQUAL_OP, 0, true,
                (values, op) =>
                    {
                        op.CheckParamCount(values.Length);
                        MeBoolean value = MathUtils.DoubleEq(values[0].Get<float>(), values[1].Get<float>());
                        return value;
                    }, CommonValidators.TwoNumbers);
        }
    }
}