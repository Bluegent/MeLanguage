using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Operators.Mathematical
{
    using Types.Var;

    public class NotOperator : IOperatorDefiner
    {
        public Operator Not { get; }
        public NotOperator()
        {
            Not = Utils.MakeOperator(LConstants.NOT_OP, 2, true,
                (values, op) =>
                {
                    op.CheckParamCount(values.Length);
                    MeBoolean result = !values[0].Get<bool>();
                    return result;
                }, new Validator((variables, operation) =>
                {
                    variables[0].Get<bool>();
                    return true;
                })
                , CommonParamTypes.SingleBoolean);
        }
        public void AddOperator(LanguageDefiner definer)
        {
            definer.AddOperator(Not);
        }
    }
}