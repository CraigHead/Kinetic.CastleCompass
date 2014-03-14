using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.CastleCompass.Core.Test
{
    [TestFixture]
    public class CompassBearing_Test
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void BearingsToCardinals()
        {
            double[] bearings = new double[] { 0.0, 90, 180, 270, 359 };
            foreach (double bearing in bearings)
            {
                var test = bearing.ToCardinal();
                Assert.IsNotNull(bearing.ToCardinal());
            }
        }
    }
}
