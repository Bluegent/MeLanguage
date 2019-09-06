namespace MeLanguage.Definer.Functions.Mathematical
{
    using System.Linq;

    using MeLanguage.Types.Var;

    public class MaxFunction : IFunctionDefiner
    {
        public void AddFunction(LanguageDefiner definer)
        {
            Function max =
                Utils.MakeFunction(LConstants.MAX_F,
                    (values, func) =>
                        {
                            func.CheckParamCount(values.Length);
                            float[] parameters = MeArray.ToFloatArray(values);
                            MeNumber maxNumber = parameters.Max();
                            return maxNumber;
                        },CommonParamTypes.SingleNumber,false);
            definer.AddFunction(max);
        }
    }
}