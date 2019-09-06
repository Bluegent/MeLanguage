using Microsoft.VisualStudio.TestTools.UnitTesting;

using MeLangTester;
using MeLanguage.Definer.Operators.Mathematical;
using MeLanguage.Types.Exceptions;
using MeLanguage.Types.Var;

namespace MeLanguage.Definer.Operators.Mathetmatical
{
    [TestClass]
    public class MathOperatorsTest
    {
        [TestMethod]
        public void DivideOperatorCanDivide()
        {
            Operator divide = new DivideOperator().Divide;
            float expected = 10.0f;

            MeVariable[] arr = { new MeNumber(100), new MeNumber(10) };
            Assert.IsTrue(divide.CanExecute(arr));
            float result = divide.Execute(arr).Get<float>();

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void DivideOperatorThrowsException()
        {
            Operator divide = new DivideOperator().Divide;
            MeVariable[] arr = { new MeString("TEST"), new MeNumber(10) };
            Assert.IsFalse(divide.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => divide.Execute(arr), typeof(MeContextException));

        }


        [TestMethod]
        public void MultiplyOperatorCanMultiply()
        {
            Operator op = new MultiplyOperator().Multiply;
            float expected = 1000.0f;

            MeVariable[] arr = { new MeNumber(100), new MeNumber(10) };
            Assert.IsTrue(op.CanExecute(arr));
            float result = op.Execute(arr).Get<float>();
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void MultiplyOperatorThrowsException()
        {
            Operator op = new MultiplyOperator().Multiply;
            MeVariable[] arr = { new MeString("TEST"), new MeNumber(10) };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));

        }


        [TestMethod]
        public void NumberEqualsCanCompare()
        {
            Operator op = new EqualsOperator().NumberEquals;
            float testNumber = 1337.0f;
            MeVariable[] arr = { new MeNumber(testNumber), new MeNumber(testNumber) };
            Assert.IsTrue(op.CanExecute(arr));
            bool result = op.Execute(arr).Get<bool>();
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void NumberEqualsCanThrow()
        {
            Operator op = new EqualsOperator().NumberEquals;
            MeVariable[] arr = { new MeStruct(""), new MeNumber(10) };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));

        }

        [TestMethod]
        public void StringEqualsCanThrow()
        {
            Operator op = new EqualsOperator().NumberEquals;
            string testString = "TEST";
            MeVariable[] arr = { new MeStruct(testString), new MeString(testString) };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));
        }


        [TestMethod]
        public void StringEqualsCanCompare()
        {
            Operator op = new EqualsOperator().StringEquals;
            string testString = "TEST_STR";
            MeVariable[] arr = {new MeString(testString), new MeString(testString)};
            Assert.IsTrue(op.CanExecute(arr));
            bool result = op.Execute(arr).Get<bool>();
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void NotOperatorCanReverse()
        {
            Operator op = new NotOperator().Not;
            MeVariable[] arr = { new MeBoolean(true) };
            Assert.IsTrue(op.CanExecute(arr));
            bool result = op.Execute(arr).Get<bool>();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void NotOperatorThrows()
        {
            Operator op = new NotOperator().Not;
            MeVariable[] arr = { new MeString("test") };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));
        }


        [TestMethod]
        public void GreaterOperatorCanCompare()
        {
            Operator op = new GreaterOperator().Greater;
            MeVariable[] arr = { new MeNumber(10), new MeNumber(20) };
            Assert.IsTrue(op.CanExecute(arr));
            bool result = op.Execute(arr).Get<bool>();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GreaterOperatorThrows()
        {
            Operator op = new GreaterOperator().Greater;
            MeVariable[] arr = { new MeString("test"), new MeNumber(10) };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));
        }



        [TestMethod]
        public void LesserOperatorCanCompare()
        {
            Operator op = new LesserOperator().Lesser;
            MeVariable[] arr = { new MeNumber(10), new MeNumber(20) };
            Assert.IsTrue(op.CanExecute(arr));
            bool result = op.Execute(arr).Get<bool>();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void LesserOperatorThrows()
        {
            Operator op = new LesserOperator().Lesser;
            MeVariable[] arr = { new MeString("test"), new MeNumber(10) };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));
        }

        [TestMethod]
        public void PlusOperatorCanAdd()
        {
            Operator op = new PlusOperator().Plus;
            MeVariable[] arr = { new MeNumber(10), new MeNumber(20) };
            Assert.IsTrue(op.CanExecute(arr));
            const float expected = 30.0f;
            float result = op.Execute(arr).Get<float>();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlusOperatorThrows()
        {
            Operator op = new PlusOperator().Plus;
            MeVariable[] arr = { new MeString("test"), new MeNumber(10) };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));
        }

        [TestMethod]
        public void MinusOperatorCanSubtract()
        {
            Operator op = new MinusOperator().Minus; 
            MeVariable[] arr = { new MeNumber(10), new MeNumber(20) };
            Assert.IsTrue(op.CanExecute(arr));
            const float expected = -10.0f;
            float result = op.Execute(arr).Get<float>();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MinusOperatorThrows()
        {
            Operator op = new MinusOperator().Minus;
            MeVariable[] arr = { new MeString("test"), new MeNumber(10) };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));
        }


        [TestMethod]
        public void PowerOperatorCanSubtract()
        {
            Operator op = new PowerOperator().Power;
            MeVariable[] arr = { new MeNumber(10), new MeNumber(2) };
            Assert.IsTrue(op.CanExecute(arr));
            const float expected = 100.0f;
            float result = op.Execute(arr).Get<float>();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PowerOperatorThrows()
        {
            Operator op = new PowerOperator().Power;
            MeVariable[] arr = { new MeString("test"), new MeNumber(10) };
            Assert.IsFalse(op.CanExecute(arr));
            TestUtils.CustomExceptionTest(() => op.Execute(arr), typeof(MeContextException));
        }
    }
}
