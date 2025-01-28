using Booking_App.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Users.Exceptions
{
    internal class NullUserException : Exception
    {
        public NullUserException() : base(ExceptionMessages.NullUserException)
        {

        }
    }
}
