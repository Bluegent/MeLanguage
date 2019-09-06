
using Language.Types.Var;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MeLangTester.Types.Var
{
    using System;

    [TestClass]
    public class MeNumberTest
    {
        [TestMethod]
        public void NumberToFloatConversion()
        {
            float value = 3.15f;
            MeVariable var = new MeNumber(value);
            Assert.AreEqual(value, var.Get<float>());
        }

        [TestMethod]
        public void NumberToLongConversion()
        {
            float value = 3.15f;
            long converted = (long)value;
            MeVariable var = new MeNumber(value);
            Assert.AreEqual(converted, var.Get<long>());
        }

        [TestMethod]
        public void NumberToIntConversion()
        {
            float value = 3.15f;
            int converted = (int)value;
            MeVariable var = new MeNumber(value);
            Assert.AreEqual(converted, var.Get<int>());
        }

        [TestMethod]
        public void InvalidConversion()
        {
            float value = 3.15f;
            MeVariable var = new MeNumber(value);
            TestUtils.CustomExceptionTest(() => var.Get<string>(), typeof(MeInvalidCastException));
        }

        [TestMethod]
        public void InvalidConversionOfLong()
        {
            long value = 123456789;
            MeVariable var = new MeNumber(value);
            TestUtils.CustomExceptionTest(() => var.Get<string>(), typeof(MeInvalidCastException));
        }
    }
}
