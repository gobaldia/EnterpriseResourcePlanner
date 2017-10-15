using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Location
    {
        private decimal latitud;
        private decimal longitud;

        public Location(decimal latitudToBeSet, decimal longitudToBeSet)
        {
            this.latitud = latitudToBeSet;
            this.longitud = longitudToBeSet;
        }

        public decimal GetLatitud()
        {
            return this.latitud;
        }
        public decimal GetLongitud()
        {
            return this.longitud;
        }
        public void SetLatitud(decimal latitudToBeSet)
        {
            this.latitud = latitudToBeSet;
        }
        public void SetLongitud(decimal longitudToBeSet)
        {
            this.longitud = longitudToBeSet;
        }

        public override bool Equals(object obj)
        {
            if (obj is Location)
            {
                return this.latitud.Equals(((Location)obj).GetLatitud()) &&
                    this.longitud.Equals(((Location)obj).GetLongitud());
            }
            else
                return false;
        }
    }
}
