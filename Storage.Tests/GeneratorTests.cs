using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Generators;

namespace Services.Tests
{
    [TestFixture]
    public class GeneratorTests
    {
        private Generator generator;
        [SetUp]
        public void Init()
        {
            generator = new Generator();
        }

        [Test]
        public void GetNewId_FirstElementIsZero_ReturnTrue()
        {
            Assert.AreEqual(0, generator.GetNewId());   
        }
        
        [Test]
        public void GetNewId_ThirdElementIsFour_ReturnTrue()
        {
            for (int i = 0; i < 2; i++)
            {
                generator.GetNewId();
            }
            Assert.AreEqual(4,generator.GetNewId());
        }

        [Test]
        public void GetNewId_IdIsEven_ReturnTrue()
        {
            for (int i = 0; i < 4; i++)
            {
                generator.GetNewId();
            }

            Assert.AreEqual(generator.GetNewId() % 2, 0);
        }

        [Test]
        public void GetNewId_1073741824IdIsZero_ReturnTrue()
        {
            int id = 0;
            for (int i = 0; i < 1073741825; i++)
            {
                id = generator.GetNewId();
            }
            Assert.AreEqual(0, id);
        }

    }
}
