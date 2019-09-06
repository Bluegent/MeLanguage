
using MeLangTester;
using MeLanguage.Definer.Creation;
using MeLanguage.Types.Exceptions;
using MeLanguage.Types.Var;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeLanguage.Definer.Functions.Mathematical
{
    [TestClass]
    public class MathFunctionTest
    {
        private static LanguageDefiner _definer;

        [ClassInitialize]
        public static void StartUp(TestContext ctx)
        {
            _definer = new BaseDefinerFactory().BuildDefiner();
        }

        [TestMethod]
        public void MinFunctionCanExecute()
        {
            Function func = new MinFunction().MinFunc;
            float expected = -10.0f;
            MeVariable[] input = { new MeNumber(14), new MeNumber(55), new MeNumber(expected) };
            Assert.IsTrue(func.CanExecute(input));
            float result = func.Execute(input).Get<float>();
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void MinFunctionThrows()
        {
            Function func = new MinFunction().MinFunc;
            float expected = -10.0f;
            MeVariable[] input = { new MeString("test"), new MeNumber(55), new MeNumber(expected) };
            Assert.IsFalse(func.CanExecute(input));
            TestUtils.CustomExceptionTest(() => func.Execute(input), typeof(MeContextException));
        }
    }
}
