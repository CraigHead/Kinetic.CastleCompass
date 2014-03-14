using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinetic.CastleCompass.Core;

namespace Kinetic.CastleCompass.Core.Test
{
    [TestFixture]
    public class WhiteCastle_Test
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void FileLoads_True()
        {
            WhiteCastle castles = new WhiteCastle();

            Assert.IsTrue(castles.TryOpenLongLats());
            Assert.IsNotEmpty(castles.Coordinates);
        }
    }
}
