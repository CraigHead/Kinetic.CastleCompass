using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinetic.CastleCompass.Core
{
    internal interface ICoordinateResource
    {
        bool TryOpenLongLats();
    }
}
