using System;
using MeLanguage.Definer.Utility;

namespace MeLanguage.Definer.Functions.Mathematical
{
    using System.Linq;

    using Types.Var;

    public class AbsFunction : IFunctionDefiner
    {
        public Function Abs { get; }

        public AbsFunction()
        {
            Abs = Utils.MakeFunction(LConstants.ABS_F,
                (values, func) =>
                {
                    func.CheckParamCount(values.Length);
                    MeNumber result = (float) Math.Abs(values[0].Get<float>());
                    return result;
                }, CommonParamTypes.SingleNumber,CommonValidators.SingleNumber);
        }

        public void AddFunction(LanguageDefiner definer)
        {

            definer.AddFunction(Abs);
        }
    }
}