using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kinetic.CastleCompass.Core.Data
{
    public class Drifters : CoordinateResource
    {
        private const string RESOURCENAME = @"Kinetic.CastleCompass.Core.Data.Drifters.csv";
        public override bool TryOpenLongLats()
        {
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(RESOURCENAME))
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
    }
}
