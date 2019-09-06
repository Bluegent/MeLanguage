using MeLanguage.Definer;
using MeLanguage.Types.Var;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeLangTester
{
    using System;

    public static class TestUtils
    {
        public static void CustomExceptionTest(Action a, Type expectedException)
        {
            try
            {
                a.Invoke();
                Assert.Fail($"Expected exception {expectedException} not thrown.");
            }
            catch (Exception e)
            {
                if (e.GetType() == expectedException)
                {
                    Console.WriteLine(e.Message);
                }
                else
                {
                    Assert.Fail($"Exception \"{e.Message}\" thrown instead of {expectedException}.");
                }
            }
        }


        public static void SuccessfulFunctionTest<T>(MeVariable[] input, Function func, T expected)
        {
            Assert.IsTrue(func.CanExecute(input));
            T result = func.Execute(input).Get<T>();
            Assert.AreEqual(expected, result);
        }

        public static void ThrowingFunctionTest(MeVariable[] input, Function func, Type exceptionType)
        {
            Assert.IsFalse(func.CanExecute(input));
            CustomExceptionTest(() => func.Execute(input), exceptionType);
        }
    }
}