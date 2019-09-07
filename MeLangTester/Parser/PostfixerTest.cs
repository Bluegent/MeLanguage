


using MeLanguage.Definer;
using MeLanguage.Definer.Creation;
using MeLanguage.Parser.Tokenize;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeLanguage.Parser
{
    [TestClass]
    public class PostfixerTest
    {
        private static MeParser _parser;
        [ClassInitialize]
        public static void StartUp(TestContext context)
        {
            LanguageDefiner definer = new BaseDefinerFactory().BuildDefiner();
            _parser = new MeParser(definer);
        }
        [TestMethod]
        public void ConverterTestSimpleFunction()
        {
            string expression = $"{LConstants.ABS_F}(STR)";
            Token[] postfix = _parser.ToPostfix(expression);
            string[] expected = { "(", "STR", LConstants.ABS_F };
            Assert.AreEqual(expected.Length, postfix.Length);
            for (int i = 0; i < postfix.Length; ++i)
                Assert.AreEqual(expected[i], postfix[i].Value);
        }

        [TestMethod]
        public void ConverterTestFunctionAndOperator()
        {
            string expression = $"{LConstants.ABS_F}(10-100)";
            Token[] postfix = _parser.ToPostfix(expression);
            string[] expected = { "(", "10", "100", "-", LConstants.ABS_F };
            Assert.AreEqual(expected.Length, postfix.Length);
            for (int i = 0; i < postfix.Length; ++i)
                Assert.AreEqual(expected[i], postfix[i].Value);
        }

        [TestMethod]
        public void ConverterTestMultipleParams()
        {
            string expression = $"{LConstants.MAX_F}(STR,INT)";
            Token[] postfix = _parser.ToPostfix(expression);
            string[] expected = { "(", "STR", "INT", LConstants.MAX_F };
            Assert.AreEqual(expected.Length, postfix.Length);
            for (int i = 0; i < postfix.Length; ++i)
                Assert.AreEqual(expected[i], postfix[i].Value);
        }


        [TestMethod]
        public void ConverterTestNestedFunctions()
        {
            string expression = $"{LConstants.ABS_F}({LConstants.MAX_F}(STR,INT))";
            Token[] postfix = _parser.ToPostfix(expression);
            string[] expected = { "(", "(", "STR", "INT", LConstants.MAX_F, LConstants.ABS_F };
            Assert.AreEqual(expected.Length, postfix.Length);
            for (int i = 0; i < postfix.Length; ++i)
                Assert.AreEqual(expected[i], postfix[i].Value);
        }

        [TestMethod]
        public void ConverterTestFunctionAndOperatorMix()
        {
            string expression = $"{LConstants.ABS_F}({LConstants.MAX_F}(STR,INT)+{LConstants.MIN_F}(10,-20))";
            Token[] postfix = _parser.ToPostfix(expression);
            string[] expected = { "(", "(", "STR", "INT", LConstants.MAX_F, "(", "10", "-20", LConstants.MIN_F, "+", LConstants.ABS_F };
            Assert.AreEqual(expected.Length, postfix.Length);
            for (int i = 0; i < postfix.Length; ++i)
                Assert.AreEqual(expected[i], postfix[i].Value);
        }


        [TestMethod]
        public void ConverterTestOperatorWithParenthesis()
        {
            string expression = "10*(2+3+4)";
            Token[] postfix = _parser.ToPostfix(expression);
            string[] expected = { "10", "2", "3", "+", "4", "+", "*" };
            Assert.AreEqual(expected.Length, postfix.Length);
            for (int i = 0; i < postfix.Length; ++i)
                Assert.AreEqual(expected[i], postfix[i].Value);
        }

        [TestMethod]
        public void ConverterTestUnaryOperator()
        {
            string expression = "!(X+Y)";
            Token[] postfix = _parser.ToPostfix(expression);
            string[] expected = { "X", "Y", "+", "!" };
            Assert.AreEqual(expected.Length, postfix.Length);
            for (int i = 0; i < postfix.Length; ++i)
                Assert.AreEqual(expected[i], postfix[i].Value);
        }
    }
}

