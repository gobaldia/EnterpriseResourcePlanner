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
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public Location()
        {
            this.Latitud = 0.00;
            this.Longitud = 0.00;
        }

        public Location(double latitudToBeSet, double longitudToBeSet)
        {
            if (!latitudRegex.IsMatch(latitudToBeSet.ToString("#.######").Replace(",", ".")))
                throw new CoreException("Invalid latitud format.");

            if (!longitudRegex.IsMatch(longitudToBeSet.ToString().Replace(",", ".")))
                throw new CoreException("Invalid longitud format.");

            this.Latitud = latitudToBeSet;
            this.Longitud = longitudToBeSet;
        }

        public double GetLatitud()
        {
            return this.Latitud;
        }
        public double GetLongitud()
        {
            return this.Longitud;
        }
        public void SetLatitud(double latitudToBeSet)
        {
            if (!latitudRegex.IsMatch(latitudToBeSet.ToString()))
                throw new CoreException("Invalid latitud format.");

            this.Latitud = latitudToBeSet;
        }
        public void SetLongitud(double longitudToBeSet)
        {
            if (!longitudRegex.IsMatch(longitudToBeSet.ToString()))
                throw new CoreException("Invalid longitud format.");

            this.Longitud = longitudToBeSet;
        }

        public override bool Equals(object obj)
        {
            if (obj is Location)
            {
                return this.Latitud.Equals(((Location)obj).GetLatitud()) &&
                    this.Longitud.Equals(((Location)obj).GetLongitud());
            }
            else
                return false;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Latitud, this.Longitud);
        }
    }
}