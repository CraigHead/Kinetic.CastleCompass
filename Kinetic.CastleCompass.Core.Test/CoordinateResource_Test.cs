using Moq;
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
    public class CoordinateResource_Test
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SphericalDistance_Should_Return_10()
        {
            TestCoordinateResource resource = new TestCoordinateResource();
            Coords here = new Coords
            {
                Latitude =  39.928780,
                Longitude = -105.139314
            };
            Coords there = new Coords
            {
                Latitude = 39.927733,
                Longitude = -105.147360
            };
            // these two coords are ~ less than 1/2 mile apart 

            var distance = resource.SphericalDistance(here, there)  * 3963.1676;  // earth radius in miles

            Assert.That(distance <= 0.5);
        }
    }

    public class TestCoordinateResource : CoordinateResource
    {

        internal override string ResourceName
        {
            get { return string.Empty; }
        }
    }
}
