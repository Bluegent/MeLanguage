using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Functions.Mathematical
{
    using System.Linq;

    using Types.Var;

    public class Absfunction : IFunctionDefiner
    {
        public Function Abs { get; }

        public Absfunction()
        {
            Abs = Utils.MakeFunction(LConstants.ABS_F,
                (values, func) =>
                {
                    func.CheckParamCount(values.Length);
                    float[] parameters = MeArray.ToFloatArray(values);
                    MeNumber maxNumber = parameters.Max();
                    return maxNumber;
                }, CommonParamTypes.SingleNumber,CommonValidators.SingleNumber, false);
        }

        public void AddFunction(LanguageDefiner definer)
        {

            definer.AddFunction(Abs);
        }
    }
}