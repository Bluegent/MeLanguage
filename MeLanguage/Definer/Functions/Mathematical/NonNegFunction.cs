using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Functions.Mathematical
{
    using Types.Var;

    public class NonNegFunction : IFunctionDefiner
    {

        public Function NonNeg;

        public NonNegFunction()
        {
            NonNeg = Utils.MakeFunction(LConstants.NON_NEG_F,
                (values, func) =>
                {
                    func.CheckParamCount(values.Length);
                    float value = values[0].Get<float>();
                    MeNumber result = value > 0 ? value : 0;
                    return result;
                }, CommonParamTypes.SingleNumber, CommonValidators.SingleNumber);
        }
        public void AddFunction(LanguageDefiner definer)
        {

            definer.AddFunction(NonNeg);
        }
    }
}