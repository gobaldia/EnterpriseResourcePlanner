using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCommon
{
    public static class Utils
    {
        public static double Distance(Location from, Location to)
        {
            return Math.Sqrt(Math.Pow(from.Latitud - to.Latitud, 2) + Math.Pow(from.Longitud - to.Longitud, 2));
        }
    }
}
