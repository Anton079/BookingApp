﻿using Booking_App.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Admins.Exceptions
{
    internal class NullAdminException : Exception
    {
        public NullAdminException() : base(ExceptionMessages.NullAdminException)
        {

        }
    }
}
