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
        internal override string ResourceName
        {
            get
            {
                return @"Kinetic.CastleCompass.Core.Data.Drifters.csv";
            }
        }
    }
}
