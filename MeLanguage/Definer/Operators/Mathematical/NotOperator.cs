namespace MeLanguage.Definer.Operators.Mathematical
{
    using MeLanguage.Types.Var;

    public class NotOperator : IOperatorDefiner
    {
        public Operator DefineOperator()
        {
            return Utils.MakeOperator(LConstants.NOT_OP, 2, true,
                (values, op) =>
                    {
                        op.CheckParamCount(values.Length);
                        MeBoolean result =  !values[0].Get<bool>();
                        return result;
                    }, new Validator((variables, operation) =>
                    {
                        variables[0].Get<bool>();
                        return true;
                    })
                , 1);
        }
    }
}