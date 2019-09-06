using MeLanguage.Definer;
using MeLanguage.Types.Var;
namespace MeLanguage.Definer.Operators.Mathematical
{
    using System;

    public class AssignOperator : IOperatorDefiner
    {
        public void AddOperator(LanguageDefiner definer)
        {
            Operator assign = Utils.MakeOperator(LConstants.ASSIGN_OP, -1, true, (values, op) =>
                {
                    throw new NotImplementedException();
                }, new Validator((variables, operation) => true), null);
            definer.AddOperator(assign);
        }
    }
}

