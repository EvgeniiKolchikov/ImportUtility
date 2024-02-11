using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Exceptions
{
    public class NotFoundRecordException : Exception
    {
        public NotFoundRecordException()
        {

        }

        public NotFoundRecordException(string message) : base(message)
        {

        }

        public NotFoundRecordException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
