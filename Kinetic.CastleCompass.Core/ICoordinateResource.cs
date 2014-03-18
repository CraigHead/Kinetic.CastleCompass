using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinetic.CastleCompass.Core
{
    internal interface ICoordinateResource
    {
        List<Coords> Coordinates { get; set; }

        bool TryOpenLongLats();

        void FindNearest(Coords me, out Coords nearestItem, out double nearestDistance);

        double SphericalDistance(Coords me, Coords item);
    }
}
