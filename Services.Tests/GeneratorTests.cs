using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void GetId_IsFirstElement_ReturnZero()
        {
            var generator = new Generator();
            Assert.AreEqual(0, generator.GetNewId());
        }

        [TestMethod]
        public void GetId_IsSecondElement_ReturnTwo()
        {
            var generator = new Generator();
            generator.GetNewId();
            Assert.AreEqual(2, generator.GetNewId());
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void GetId_IsOverflow_ReturnAnException()
        {
            var generator = new Generator();
            for (int i = 0; i < int.MaxValue; i++)
            {
                generator.GetNewId();
            }
        }

        [TestMethod]
        public void GetId_IsEven_ReturnTrue()
        {
            var generator = new Generator();
            for (int i = 0; i < 4; i++)
            {
                generator.GetNewId();
            }

            Assert.AreEqual(generator.GetNewId() % 2, 0);
        }
    }
}

