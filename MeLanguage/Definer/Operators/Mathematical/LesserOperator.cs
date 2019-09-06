﻿namespace MeLanguage.Definer.Operators.Mathematical
{
    using MeLanguage.Types.Var;
    public class LesserOperator : IOperatorDefiner
    {
        public Operator DefineOperator()
        {
            return Utils.MakeOperator(LConstants.LESSER_OP, 0, true,
                 (values, op) =>
                     {
                         op.CheckParamCount(values.Length);
                         MeBoolean result =  values[0].Get<float>() < values[1].Get<float>();
                         return result;
                     }, CommonValidators.TwoNumbers);
        }
    }
}