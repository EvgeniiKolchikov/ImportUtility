using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Exceptions
{
    public class DuplicateMappingException : Exception
    {
        public DuplicateMappingException()
        {

        }

        public DuplicateMappingException(string message) : base(message)
        {

        }

        public DuplicateMappingException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
