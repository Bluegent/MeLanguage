﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using MeLanguage.Types.Exceptions;
using MeLanguage.Types.Var;
namespace MeLangTester.Types.Var
{


    [TestClass]
    public class MeStructTest
    {
        [TestMethod]
        public void CanCastToTypes()
        {
            string structName = "TEST_STRUCT";
            MeVariable aStruct = new MeStruct(structName);
            MeStruct castedStruct = aStruct.Get<MeStruct>();
            Assert.IsNotNull(castedStruct);
            Assert.AreEqual(structName, castedStruct.GetName());
        }

        [TestMethod]
        public void InvalidCast()
        {
            string structName = "TEST_STRUCT";
            MeVariable aStruct = new MeStruct(structName);
            TestUtils.CustomExceptionTest(() => aStruct.Get<long>(), typeof(MeInvalidCastException));
        }
    }

}
