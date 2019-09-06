using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Language.Definer.Operators.Mathetmatical
{
    using MeLangTester;

    using MeLanguage.Definer;
    using MeLanguage.Definer.Operators.Mathematical;
    using MeLanguage.Types.Exceptions;
    using MeLanguage.Types.Var;
    using MeLanguage.Utility;

    [TestClass]
    public class MathOperatorsTest
    {
        [TestMethod]
        public void DivideOperatorCanDivide()
        {
            Operator divide = new DivideOperator().Divide;

            float expected = 10.0f;
            float result = divide.Execute(new MeVariable[] { new MeNumber(100), new MeNumber(10), }).Get<float>();

            Assert.AreEqual(expected,result);

        }

        [TestMethod]
        public void DivideOperatorThrowsException()
        {
            Operator divide = new DivideOperator().Divide;

            float expected = 10.0f;
            MeVariable[] arr =  { new MeString("TEST"), new MeNumber(10) };
            TestUtils.CustomExceptionTest( () => divide.Execute(arr),typeof(MeContextException));

        }


        [TestMethod]
        public void MultiplyOperatorTest()
        {
            Operator op = new MultiplyOperator().Multiply;

            float expected = 100.0f;
            float result = op.Execute(new MeVariable[] { new MeNumber(10), new MeNumber(10), }).Get<float>();

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void EqualsOperatorStringTest()
        {
            Operator op = new EqualsOperator().NumberEquals;
            float testNumber = 1337.0f;
            bool result = op.Execute(new MeVariable[] { new MeNumber(testNumber), new MeNumber(testNumber), }).Get<bool>();
            Assert.IsTrue( result);

        }


        [TestMethod]
        public void EqualsOperatorNumberTest()
        {
            Operator op = new EqualsOperator().StringEquals;
            string testString = "TEST_STR";
            bool result = op.Execute(new MeVariable[] { new MeString(testString), new MeString(testString)}).Get<bool>();
            Assert.IsTrue(result);

        }
    }
}
