using MeLanguage.Types.Var;

namespace MeLanguage.Definer.Utility
{
    public static class CommonValidators
    {
        public static readonly Validator TwoNumbers = new Validator(
            (values, op) =>
            {
                values[0].Get<float>();
                values[1].Get<float>();
                return true;
            });
        public static readonly Validator TwoStrings = new Validator(
            (values, op) =>
            {
                values[0].Get<string>();
                values[1].Get<string>();
                return true;
            });
        public static readonly Validator NumberArray = new Validator((values, op) =>
        {
            MeArray.ToFloatArray(values);
            return true;
        });
        public static readonly  Validator SingleNumber = new Validator((values, op) =>
        {
            values[0].Get<float>();
            return true;
        });
    }
}