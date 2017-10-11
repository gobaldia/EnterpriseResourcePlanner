using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public abstract class Person
    {
        private Regex regex = new Regex("^[0-9]{7}-[0-9]{1}$");
        protected string Name { get; set; }
        protected string LastName { get; set; }
        private string _document;
        protected string Document
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
