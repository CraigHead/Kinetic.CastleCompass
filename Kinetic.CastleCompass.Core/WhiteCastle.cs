using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kinetic.CastleCompass.Core
{
    public class WhiteCastle : CoordinateResource
    {
        internal override string ResourceName
        {
            get
            {
                return @"Kinetic.CastleCompass.Core.Data.White Castle.csv";
            }
        }
    }
}
