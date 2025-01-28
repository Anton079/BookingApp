using Booking_App.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.TravelHistorys
{
    internal class InvalidTravelHistoryIdException : Exception
    {
        public InvalidTravelHistoryIdException() : base(ExceptionMessages.InvalidTravelHistoryIdException)
        {

        }
    }
}
