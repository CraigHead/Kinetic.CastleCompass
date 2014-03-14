using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinetic.CastleCompass.Core
{
    public static class CompassBearing
    {
        public static double CalculateBearing(Coords pointA, Coords pointB)
        {
            double lat1 = pointA.Latitude.ToRadian();
            double lat2 = pointB.Latitude.ToRadian();

            double deltaLong = (pointB.Longitude - pointA.Longitude).ToRadian();

            double x = Math.Sin(deltaLong) * Math.Cos(lat2);
            double y = Math.Cos(lat1) * Math.Sin(lat2) - (Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(deltaLong));

            double initialBearing = Math.Atan2(y, x).ToDegrees();
            double compassBearing = (initialBearing + 360) % 360;
            
            return compassBearing;
        }

        public static string ToCardinal(this double bearing)
        {
            List<string> cardinals = new List<string> { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
            double circaPercentage = (bearing / 360.0) + 0.03125;
            if (circaPercentage > 1.0)
                circaPercentage -= 1.0;
            int cardinalIndex = Convert.ToInt32(circaPercentage * cardinals.Count);
            return cardinals[cardinalIndex];
        }

        public static double ToRadian(this double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        public static double ToDegrees(this double radians)
        {
            return radians * (180.0 / Math.PI);
        }
    }
}
