using CoreEntities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Location
    {
        private Regex latitudRegex = new Regex("^(\\+|-)?(?:90(?:(?:\\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\\.[0-9]{1,6})?))$");
        private Regex longitudRegex = new Regex("^(\\+|-)?(?:180(?:(?:\\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\\.[0-9]{1,6})?))$");
        private double latitud;
        private double longitud;

        public Location(double latitudToBeSet, double longitudToBeSet)
        {
            if (!latitudRegex.IsMatch(latitudToBeSet.ToString()))
                throw new CoreException("Invalid latitud format.");

            if (!longitudRegex.IsMatch(longitudToBeSet.ToString()))
                throw new CoreException("Invalid longitud format.");

            this.latitud = latitudToBeSet;
            this.longitud = longitudToBeSet;
        }

        public double GetLatitud()
        {
            return this.latitud;
        }
        public double GetLongitud()
        {
            return this.longitud;
        }
        public void SetLatitud(double latitudToBeSet)
        {
            if (!latitudRegex.IsMatch(latitudToBeSet.ToString()))
                throw new CoreException("Invalid latitud format.");

            this.latitud = latitudToBeSet;
        }
        public void SetLongitud(double longitudToBeSet)
        {
            if (!longitudRegex.IsMatch(longitudToBeSet.ToString()))
                throw new CoreException("Invalid longitud format.");

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
