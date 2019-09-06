using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Language.Definer.Operators.Mathetmatical
{
    using MeLanguage.Definer;
    using MeLanguage.Definer.Operators.Mathematical;
    using MeLanguage.Types.Var;
    using MeLanguage.Utility;

    [TestClass]
    public class MathOperatorsTest
    {
        [TestMethod]
        public void DivideOperatorTest()
        {
            Operator divide = new DivideOperator().Divide;

            float expected = 10.0f;
            float result = divide.Execute(new[] { new MeNumber(100), new MeNumber(10), }).Get<float>();

            Assert.AreEqual(expected,result);

        }
    }
}
