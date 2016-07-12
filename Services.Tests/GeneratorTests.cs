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
            var sequence = Generator.GetEvenSequence();
            Assert.IsNotNull(sequence);
            sequence.MoveNext();
            Assert.AreEqual(0, sequence.Current);
        }

        [TestMethod]
        public void GetId_IsSecondElement_ReturnTwo()
        {
            var sequence = Generator.GetEvenSequence();
            sequence.MoveNext();
            sequence.MoveNext();
            Assert.AreEqual(2, sequence.Current);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void GetId_IsOverflow_ReturnAnException()
        {
            var sequence = Generator.GetEvenSequence();
            for (int i = 0; i < int.MaxValue; i++)
            {
                sequence.MoveNext();
            }
        }

        [TestMethod]
        public void GetId_IsEven_ReturnTrue()
        {
            var a = Generator.GetEvenSequence();
            for (int i = 0; i < 4; i++)
            {
                a.MoveNext();
            }

            Assert.AreEqual(a.Current % 2, 0);
        }
    }
}

