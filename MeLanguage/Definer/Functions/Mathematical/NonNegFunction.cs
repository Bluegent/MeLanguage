namespace MeLanguage.Definer.Functions.Mathematical
{
    using MeLanguage.Types.Var;

    public class NonNegFunction : IFunctionDefiner
    {
        public void AddFunction(LanguageDefiner definer)
        {
            Function nonNeg =
                Utils.MakeFunction(LConstants.NON_NEG_F,
                    (values, func) =>
                        {
                            func.CheckParamCount(values.Length);
                            float value = values[0].Get<float>();
                            MeNumber result = value > 0 ? value : 0;
                            return result;
                        }, CommonParamTypes.SingleNumber);
            definer.AddFunction(nonNeg);
        }
    }
}