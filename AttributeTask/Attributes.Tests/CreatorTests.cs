using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.Tests
{
    [TestFixture]
    public class CreatorTests
    {
        [Test]
        public void Create_CreateUsers_ReturnEnumerableWithNonZeroLength()
        {
            var creator = new Creator();
            Assert.AreNotEqual(0,creator.Create(typeof(User)));
        }

        [Test]
        public void Create_CreateAdvancedUsers_ReturnEnumerableWithNonZeroLength()
        {
            var creator = new Creator();
            Assert.AreNotEqual(0, creator.Create(typeof(AdvancedUser)));
        }
    }
}
