using System;
using MeLanguage.Definer;
using MeLanguage.Definer.Creation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeLanguage.Parser.Tokenize
{
    [TestClass]
    public class TokenizerTest
    {

        private static LanguageDefiner _definer;
        private Tokenizer _tokenizer;

        [ClassInitialize]
        public static void StartUp(TestContext context)
        {
            _definer = new BaseDefinerFactory().BuildDefiner();
        }

        [TestInitialize]
        public void Init()
        {
            _tokenizer = new Tokenizer(_definer);
        }

        [TestMethod]
        public void TokenizerTestEmptyExpression()
        {
            string expression = "";
            Assert.AreEqual(0, _tokenizer.Tokenize(expression).Length);
        }

        [TestMethod]
        public void TokenizerTestEmptySpacedExpression()
        {
            string expression = "                   \n\r\t";
            Assert.AreEqual(0, _tokenizer.Tokenize(expression).Length);
        }


        [TestMethod]
        public void TokenizerTestNormalExpression()
        {
            string expression = "MAX(STR*10,INT*10)";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "MAX", "(", "STR", "*", "10", ",", "INT", "*", "10", ")" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }

        [TestMethod]
        public void TokenizerTestFunctionAndOperatorMix()
        {
            string expression = "ABS(10-100)";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "ABS", "(", "10", "-", "100", ")" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }


        [TestMethod]
        public void TokenizerTestNegativeVar()
        {
            string expression = "ABS(-10)";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "ABS", "(", "-10", ")" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }


        [TestMethod]
        public void TokenizerTestNestedFunctions()
        {
            string expression = "MAX(ABS(10))";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "MAX", "(", "ABS", "(", "10", ")", ")" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }

        [TestMethod]
        public void TokenizerTestSpacedExpression()
        {
            string expression = "MAX   (    STR  *\n10,\n\r    INT*10)";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "MAX", "(", "STR", "*", "10", ",", "INT", "*", "10", ")" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }

        [TestMethod]
        public void TokenizerTestDoubleValue()
        {
            string expression = "10.5-3";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "10.5", "-", "3" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }

        [TestMethod]
        public void TokenizerTestUnaryOperator()
        {
            string expression = "!TRUE";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "!", "TRUE" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }

        [TestMethod]
        public void TokenizerTestMulticharOperator()
        {
            string expression = "10 == 3";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "10", "==", "3" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }

        [TestMethod]
        public void TokenizerTestParseString()
        {
            string inner = "It's barbie bitcheeeees!";
            string expression = $"SAY(\"{inner}\")";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "SAY", "(", inner, ")" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }

        [TestMethod]
        public void TokenizerTestParseNewLineString()
        {
            string inner = "It's\n barbie \nbitcheeeees!";
            string expression = $"SAY(\"{inner}\")";
            Token[] resultTokens = _tokenizer.Tokenize(expression);
            String[] expectedTokens = { "SAY", "(", inner, ")" };
            Assert.AreEqual(expectedTokens.Length, resultTokens.Length);
            for (int i = 0; i < resultTokens.Length; ++i)
                Assert.AreEqual(expectedTokens[i], resultTokens[i].Value);
        }
    }
}
