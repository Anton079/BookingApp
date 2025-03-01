﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.System
{
    public static class ExceptionMessages
    {
        //Property
        public static readonly string PropertyNotFoundException = "Proprietatea nu a fost gasita!";
        public static readonly string NullPropertyException = "Proprietatea nu poate fi null";

        //Customer
        public static readonly string CustomerNotFoundException = "Customer nu a fost gasit!";
        public static readonly string NullCustomerException = "Customer nu poate fi null";

        //Admin
        public static readonly string NullAdminException = "Admin nu poate fi null";
        public static readonly string AdminNotFoundException = "Admin nu paote fi gasit!";

        //User
        public static readonly string UserNotFoundException = "Userul nu a fost gasit!";
        public static readonly string NullUserException = "Userul nu poate fi null!";

        //travelHistory
        public static readonly string NullTravelHistoryException = "Travel History nu poate fi null";
        public static readonly string InvalidTravelHistoryIdException = "TravelHistory id nu poate fi gasit";
    }
}
