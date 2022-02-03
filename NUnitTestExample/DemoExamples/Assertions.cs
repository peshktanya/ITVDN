using NUnit.Framework;
using System;

namespace NUnitTestExample.DemoExamples
{
    public class Assertions
    {
        [Test]
        public void SumAssertionsTest()
        {
            int a = 5;
            int b = 2;
            int sum = a + b;
            Assert.That(sum == 7);
            Assert.AreEqual(8, sum);
            Assert.Greater(sum, 5);        
        }

        [Test]
        public void MultipleAssertionsTest()
        {
            int a = 5;
            int b = 2;
            int sum = a + b;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(7, sum);
                Console.WriteLine("Equal assert");
                Assert.Greater(sum, 8);
                Assert.Negative(a / b);
            });
        }
    }
}
