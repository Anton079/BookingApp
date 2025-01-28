using Booking_App.TravelHistorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.TravelHistorys.Service
{
    public interface ITravelHistoryCommandService
    {
        TravelHistory AddTravelHistory(TravelHistory travelHistory);

        void RemoveTravelHistory(int id);

        TravelHistory UpdateTravelHistory(int id, TravelHistory travelHistory);

        int GenerateId();

    }
}
