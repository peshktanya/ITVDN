using NUnit.Framework;
using System.Threading.Tasks;

namespace NUnitTestExample.DemoExamples
{
    class AttributeTest
    {
        // A simple test
        [Test]
        public void Add()
        { /* ... */ }

        // A test with a description property
        [Test(Description = "My really cool test")]
        public void FirstMethod()
        { /* ... */ }

        // Alternate way to specify description as a separate attribute
        [Test, Description("My really really cool test")]
        public void AnotherMethod()
        { /* ... */ }

        // A simple async test
        [Test, Author("Tetiana")]
        public async Task AddAsync()
        {
            Task task = Task.Delay(1000); //асинхронная операция
            await task;
        }

        // Test with an expected result
        [Test(ExpectedResult = "Google")]
        public string TestAdd()
        {
            return "Google";
        }

        // Async test with an expected result
        [Test(ExpectedResult = 4)]
        public async Task<int> TestAddAsync()
        {

            Task task = Task.Delay(1000); //асинхронная операция
            await task;
            return 2 + 2;
        }
    }

}
