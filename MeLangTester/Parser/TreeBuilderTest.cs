﻿using System;
using MeLanguage.Definer;
using MeLanguage.Definer.Creation;
using MeLanguage.Parser.Build;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeLanguage.Parser
{

    [TestClass]
    public class TreeBuilderTest
    {
        public static MeParser _parser;

        [ClassInitialize]
        public static void StartUp(TestContext context)
        {
            _parser = new MeParser(new BaseDefinerFactory().BuildDefiner());
        }

        [TestMethod]
        public void TreeBuilderTestSingleParamFunction()
        {
            string expression = $"{LConstants.ABS_F}(STR)";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {"STR"};
            Assert.AreEqual(LConstants.ABS_F, tree.Token.Value);
            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);
        }

        [TestMethod]
        public void TreeBuilderTestMultipleParamFunction()
        {
            string expression = $"{LConstants.MAX_F}(STR,10,INT)";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {"STR", "10", "INT"};
            Assert.AreEqual(LConstants.MAX_F, tree.Token.Value);
            Assert.AreEqual(expected.Length, tree.Parameters.Count);
            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);
        }

        [TestMethod]
        public void TreeBuilderTestOperator()
        {
            string expression = "STR+INT";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {"STR", "INT"};
            Assert.AreEqual("+", tree.Token.Value);
            Assert.AreEqual(expected.Length, tree.Parameters.Count);
            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);
        }

        [TestMethod]
        public void TreeBuilderTestNestedOperators()
        {
            string expression = "STR+INT*10";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {"STR", "*"};
            string[] nestedExpect = {"INT", "10"};
            Assert.AreEqual("+", tree.Token.Value);
            Assert.AreEqual(expected.Length, tree.Parameters.Count);
            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);

            TokenNode subNode = tree.Parameters[0];
            for (int i = 0; i < subNode.Parameters.Count; ++i)
                Assert.AreEqual(nestedExpect[i], subNode.Parameters[i].Token.Value);
        }

        [TestMethod]
        public void TreeBuilderTestNestedOperatorsAndFunctions()
        {
            string expression = $"STR+{LConstants.MAX_F}(10,11,12)";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {"STR", LConstants.MAX_F};
            string[] nestedExpect = {"10", "11", "12"};
            Assert.AreEqual("+", tree.Token.Value);
            Assert.AreEqual(expected.Length, tree.Parameters.Count);
            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);

            TokenNode subNode = tree.Parameters[1];
            for (int i = 0; i < subNode.Parameters.Count; ++i)
                Assert.AreEqual(nestedExpect[i], subNode.Parameters[i].Token.Value);
        }

        [TestMethod]
        public void TreeBuilderTestNestedFunctions()
        {
            string expression = $"{LConstants.ABS_F}({LConstants.MAX_F}(STR,INT,AGI))";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {LConstants.MAX_F};
            string[] nestedExpect = {"STR", "INT", "AGI"};
            Assert.AreEqual(LConstants.ABS_F, tree.Token.Value);
            Assert.AreEqual(expected.Length, tree.Parameters.Count);

            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);

            TokenNode subNode = tree.Parameters[0];
            for (int i = 0; i < subNode.Parameters.Count; ++i)
                Assert.AreEqual(nestedExpect[i], subNode.Parameters[i].Token.Value);
        }

        [TestMethod]
        public void TreeBuilderMixOfOperatorsAndFunctions()
        {
            string expression = $"{LConstants.MAX_F}(STR,AGI) + {LConstants.MIN_F}(10,INT)";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {LConstants.MAX_F, LConstants.MIN_F};
            string[] nestedExpect = {"STR", "AGI"};
            string[] nestedExpect2 = {"10", "INT"};
            Assert.AreEqual("+", tree.Token.Value);
            Assert.AreEqual(expected.Length, tree.Parameters.Count);

            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);

            TokenNode subNode = tree.Parameters[0];
            for (int i = 0; i < subNode.Parameters.Count; ++i)
                Assert.AreEqual(nestedExpect[i], subNode.Parameters[i].Token.Value);


            TokenNode subNode2 = tree.Parameters[1];
            for (int i = 0; i < subNode2.Parameters.Count; ++i)
                Assert.AreEqual(nestedExpect2[i], subNode2.Parameters[i].Token.Value);
        }

        [TestMethod]
        public void TreeBuilderUnaryOperator()
        {
            string expression = "!(X>Y)";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {">"};
            string[] nestedExpect = {"X", "Y"};
            Assert.AreEqual("!", tree.Token.Value);
            Assert.AreEqual(expected.Length, tree.Parameters.Count);

            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);

            TokenNode subNode = tree.Parameters[0];
            for (int i = 0; i < subNode.Parameters.Count; ++i)
                Assert.AreEqual(nestedExpect[i], subNode.Parameters[i].Token.Value);
        }

        [TestMethod]
        public void TreeBuilderBooleanOperatorPrecedence()
        {
            string expression = "X>Y+Z";
            TokenNode tree = _parser.BuildTree(expression);
            string[] expected = {"X", "+"};
            string[] nestedExpect = {"Y", "Z"};
            Assert.AreEqual(">", tree.Token.Value);

            Assert.AreEqual(expected.Length, tree.Parameters.Count);
            for (int i = 0; i < tree.Parameters.Count; ++i)
                Assert.AreEqual(expected[i], tree.Parameters[i].Token.Value);

            TokenNode subNode = tree.Parameters[1];
            Assert.AreEqual(nestedExpect.Length, subNode.Parameters.Count);
            for (int i = 0; i < subNode.Parameters.Count; ++i)
                Assert.AreEqual(nestedExpect[i], subNode.Parameters[i].Token.Value);


        }
    }
}