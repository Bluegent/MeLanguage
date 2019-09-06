
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
            Function func = new MinFunction().Min;
            float expected = -10.0f;
            MeVariable[] input = { new MeNumber(14), new MeNumber(55), new MeNumber(expected) };
            Assert.IsTrue(func.CanExecute(input));
            float result = func.Execute(input).Get<float>();
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void MinFunctionThrows()
        {
            Function func = new MinFunction().Min;
            MeVariable[] input = { new MeString("test"), new MeNumber(55), new MeNumber(30) };
            Assert.IsFalse(func.CanExecute(input));
            TestUtils.CustomExceptionTest(() => func.Execute(input), typeof(MeContextException));
        }

        [TestMethod]
        public void MaxFunctionCanExecute()
        {
            Function func = new MaxFunction().Max;
            float expected = 100.0f;
            MeVariable[] input = { new MeNumber(14), new MeNumber(55), new MeNumber(expected) };
            Assert.IsTrue(func.CanExecute(input));
            float result = func.Execute(input).Get<float>();
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void MaxFunctionThrows()
        {
            Function func = new MaxFunction().Max;
            MeVariable[] input = { new MeString("test"), new MeNumber(55), new MeNumber(30) };
            Assert.IsFalse(func.CanExecute(input));
            TestUtils.CustomExceptionTest(() => func.Execute(input), typeof(MeContextException));
        }


        [TestMethod]
        public void AbsFunctionCanExecute()
        {
            float expected = 100.0f;
            MeVariable[] input = { new MeNumber(-1 * expected)};
            TestUtils.SuccessfulFunctionTest(input, new Absfunction().Abs, expected);

        }

        [TestMethod]
        public void AbsFunctionThrows()
        {
            MeVariable[] input = { new MeString("test")};
            TestUtils.ThrowingFunctionTest(input, new Absfunction().Abs, typeof(MeContextException));
        }
    }
}
