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
    }
}