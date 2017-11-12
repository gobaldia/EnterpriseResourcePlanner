using CoreEntities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public abstract class Person
    {
        private Regex regex = new Regex("^[0-9]{7}-[0-9]{1}$");

        public int PersonOID { get; set; } // This id is used by EntityFramework.
        public string Name { get; set; }
        public string LastName { get; set; }
        private string _document;
        public string Document
        {
            get { return this._document; }
            set
            {
                if (regex.IsMatch(value))
                    this._document = value;
                else
                    throw new CoreException("Invalid document number format.");
            }
        }

        public virtual string GetFullName()
        {
            return string.Format("{0} {1}", this.Name, this.LastName);
        }
    }
}
