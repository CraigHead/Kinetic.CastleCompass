using System;
using System.Collections.Generic;
using System.Linq;
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

        public abstract bool TryOpenLongLats();

        public void FindNearest(Coords me)
        {
            
        }
    }
}
