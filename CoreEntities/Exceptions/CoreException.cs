using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Exceptions
{
    public class CoreException : Exception
    {
        public CoreException() { }

        public CoreException(string message)
        : base(message) { }

        public CoreException(string message, Exception inner)
        : base(message, inner) { }
    }
}
