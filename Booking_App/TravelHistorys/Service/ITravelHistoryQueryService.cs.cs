using Booking_App.TravelHistorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.TravelHistorys.Service
{
    public interface ITravelHistoryQueryService
    {
        List<TravelHistory> GetAllTravelHistories();

        TravelHistory GetTravelHistoryById(int id);

    }
}
