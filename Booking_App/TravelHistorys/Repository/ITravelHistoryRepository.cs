using Booking_App.TravelHistorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.TravelHistorys.Repository
{
    public interface ITravelHistoryRepository
    {
        List<TravelHistory> GetAll();

        TravelHistory AddTravelHistory(TravelHistory travelHistory);

        TravelHistory Remove(int id);

        TravelHistory FindById(int id);

        TravelHistory UpdateTravelHistory(int id, TravelHistory travelHistory);

    }
}
