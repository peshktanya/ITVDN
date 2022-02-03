using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace NUnitTestExample.DemoExamples
{
    [TestFixture("one")]
    [TestFixture("two")]
    [TestFixture("zero", "four")]
    public class AttributeTestFixture
    {
        private string str;
        private string str2;

        public AttributeTestFixture(string text)
        {
            str = text;
        }

        public AttributeTestFixture(string text, string text2)
        {
            str = text;
            str2 = text2;
        }

        [Test]
        public void ContainsCharacter()
        {
            Assert.That(str.Contains("o"));

            if (str2 != null) 
            {
                Assert.That(str2.Contains("o"));
            }

        }
    }


    [TestFixture(typeof(ArrayList))]
    [TestFixture(typeof(List<int>))]
    public class IList_Tests<TList> where TList : IList, new()
    {
        private IList list;

        [SetUp]
        public void CreateList()
        {
            this.list = new TList();
        }

        [Test]
        public void CanAddToList()
        {
            list.Add(1); list.Add(2); list.Add(3);
            Assert.AreEqual(3, list.Count);
        }
    }

}
