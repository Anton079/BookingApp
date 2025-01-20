using Booking_App.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Propertys.Exceptions
{
    internal class NullPropertyException : Exception
    {
        public NullPropertyException() : base(ExceptionMessages.NullPropertyException)
        {

        }
    }
}
