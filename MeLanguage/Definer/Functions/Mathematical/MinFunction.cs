using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Functions.Mathematical
{
    using System.Linq;

    using Types.Var;

    public class MinFunction : IFunctionDefiner
    {
        public Function MinFunc { get; }

        public MinFunction()
        {
            MinFunc = Utils.MakeFunction(LConstants.MIN_F,
                (values, func) =>
                {
                    func.CheckParamCount(values.Length);
                    float[] parameters = MeArray.ToFloatArray(values);
                    MeNumber maxNumber = parameters.Max();
                    return maxNumber;
                }, CommonParamTypes.SingleNumber, CommonValidators.NumberArray, false);
        }

        public void AddFunction(LanguageDefiner definer)
        {
               
            definer.AddFunction(MinFunc);
        }
    }
}