using NUnit.Framework;

namespace NUnitTestExample.DemoExamples
{
    public class TestCaseSourceExample
    {
        static int[] EvenNumbers = new int[] { 2, 4, 6, 8, 11 };

        [TestCaseSource(nameof(EvenNumbers))]
        public void NumberShouldNotBeOddTest(int num)
        {
            Assert.IsTrue(num % 2 == 0);
        }
    }


    public class TestCaseSourceFixture
    {
        [TestCaseSource(typeof(AnotherClass), nameof(AnotherClass.DivideCases))]
        public void DivideTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }
    }

    class AnotherClass
    {
        public static object[] DivideCases =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };
    }
}
