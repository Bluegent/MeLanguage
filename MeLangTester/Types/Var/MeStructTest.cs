using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeLangTester.Types.Var
{
    using Language.Types.Var;

    [TestClass]
    public class MeStructTest
    {
        [TestMethod]
        public void CanCastToTypes()
        {
            string structName = "TEST_STRUCT";
            MeVariable aStruct = new MeStruct(structName);

            Assert.AreEqual(structName,aStruct.Get<string>());
            MeStruct castedStruct = aStruct.Get<MeStruct>();
            Assert.IsNotNull(castedStruct);
            Assert.AreEqual(structName, castedStruct.GetName());
        }

        [TestMethod]
        public void InvalidCast()
        {
            string structName = "TEST_STRUCT";
            MeVariable aStruct = new MeStruct(structName);
            void TestMethod() => aStruct.Get<long>();
            TestUtils.CustomExceptionTest(TestMethod,typeof(MeInvalidCastException));
        }
    }
}
