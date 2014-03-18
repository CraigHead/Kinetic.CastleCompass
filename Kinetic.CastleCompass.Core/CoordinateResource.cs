using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kinetic.CastleCompass.Core
{
    public abstract class CoordinateResource : ICoordinateResource
    {
        private List<Coords> _coordinates;
        public List<Coords> Coordinates
        {
            get
            {
                if (_coordinates == null)
                    _coordinates = new List<Coords>();
                return _coordinates;
            }
            set
            {
                _coordinates = value;
            }
        }

        internal abstract string ResourceName { get; }

        public bool TryOpenLongLats()
        {
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(this.ResourceName))
            {
                if (resourceStream == null)
                    return false;

                using (TextReader reader = new StreamReader(resourceStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        double latitude;
                        double longitude;

                        string[] pairs = line.Split(',');

                        if (double.TryParse(pairs[0], out latitude) && double.TryParse(pairs[1], out longitude))
                        {
                            Coordinates.Add(new Coords { Longitude = longitude, Latitude = latitude });
                        }
                    }
                }
                return true;
            }
        }

        public void FindNearest(Coords me, out Coords nearestItem, out double nearestDistance)
        {
            nearestItem = new Coords();
            nearestDistance = double.NaN;

            foreach (Coords item in this.Coordinates)
            {
                double itemDistance = SphericalDistance(me, item) * 3963.1676;  // earth radius in miles
                if (double.IsNaN(nearestDistance) || itemDistance < nearestDistance)
                {
                    nearestItem = item;
                    nearestDistance = itemDistance;
                }
            }
        }

        public double SphericalDistance(Coords me, Coords item)
        {
            double degreesToRadians = Math.PI / 180.0;

            // phi = 90deg - latitude
            double mePhi = (90.0 - me.Latitude) * degreesToRadians;
            double itemPhi = (90.0 - item.Latitude) * degreesToRadians;

            // theta = longitude
            double meTheta = me.Longitude * degreesToRadians;
            double itemTheta = item.Longitude * degreesToRadians;

            // Compute spherical distance from spherical coordinates


            // For two locations in spherical coordinates
            // (1, theta, phi) and (1, theta, phi)
            // cosine( arc length ) =
            //    sin phi sin phi' cos(theta-theta') + cos phi cos phi'
            // distance = rho * arc length

            double cos = (Math.Sin(mePhi) * Math.Sin(itemPhi) * Math.Cos(meTheta - itemTheta) +
                   Math.Cos(mePhi) * Math.Cos(itemPhi));
            double arc = Math.Acos(cos);

            // Remember to multiply arc by the radius of the earth
            // in your favorite set of units to get length.
            return arc;
        }
    }
}
