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

        public void FindNearest(Coords me)
        {
            
        }
    }
}
