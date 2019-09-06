using MeLanguage.Types.Var;
namespace MeLanguage.Definer.Operators.Mathematical
{
    using System.Runtime.Remoting.Messaging;

    public class DivideOperator : IOperatorDefiner
    {
        public Operator DefineOperator()
        {
            return Utils.MakeOperator(LConstants.DIVIDE_OP, 2, true,
                (values, op) =>
                {
                    op.CheckParamCount(values.Length);
                   MeNumber result = values[0].Get<float>() / values[1].Get<float>();
                   return result;
                }, CommonValidators.TwoNumbers, CommonParamTypes.TwoNumbers);
        }
    }
}