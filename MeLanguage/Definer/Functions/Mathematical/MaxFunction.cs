using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Functions.Mathematical
{
    using System.Linq;

    using Types.Var;

    public class MaxFunction : IFunctionDefiner
    {
        public Function Max { get; }
        public MaxFunction()
        {
            Max = Utils.MakeFunction(LConstants.MAX_F,
                (values, func) =>
                {
                    func.CheckParamCount(values.Length);
                    float[] parameters = MeArray.ToFloatArray(values);
                    MeNumber maxNumber = parameters.Max();
                    return maxNumber;
                }, CommonParamTypes.SingleNumber, CommonValidators.NumberArray ,false);
        }
        public void AddFunction(LanguageDefiner definer)
        {

            definer.AddFunction(Max);
        }
    }
}