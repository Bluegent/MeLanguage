using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Language.Definer
{
    using MeLanguage.Definer;
    using MeLanguage.Definer.Functions.Mathematical;
    using MeLanguage.Types.Var;

    [TestClass]
    public class DefinerTest
    {
        [TestMethod]
        public void CanAddNoParameterCountFunctionAndRetrieveIt()
        {
            LanguageDefiner definer = new LanguageDefiner();
            IFunctionDefiner max = new MaxFunction();
            max.AddFunction(definer);
            MeVariable[] vars =  { new MeNumber(100), new MeNumber(20) };
            MeVariable[] vars2 = { new MeNumber(100), new MeNumber(20), new MeNumber(400) };
            Function maxFunc = definer.GetFunction(LConstants.MAX_F, vars);
            Function maxFunc2 = definer.GetFunction(LConstants.MAX_F, vars2);
            Assert.IsNotNull(maxFunc);
            Assert.IsNotNull(maxFunc2);
            Assert.AreEqual(maxFunc2,maxFunc);
        }

        [TestMethod]
        public void CanAddSingleParameterCountFunctionAndRetrieveIt()
        {
            LanguageDefiner definer = new LanguageDefiner();
            IFunctionDefiner func = new NonNegFunction();
            func.AddFunction(definer);
            MeVariable[] vars = { new MeNumber(100)};
            MeVariable[] vars2 = { new MeNumber(-30)};
            int hash1 = MeArray.GetTypeHashCode(vars);
            int hash2 = MeArray.GetTypeHashCode(vars2);
            Function retFunc = definer.GetFunction(LConstants.NON_NEG_F, vars);
            Function retFunc2 = definer.GetFunction(LConstants.NON_NEG_F, vars2);
            Assert.IsNotNull(retFunc);
            Assert.IsNotNull(retFunc2);
            Assert.AreEqual(retFunc, retFunc2);
        }
    }
}
