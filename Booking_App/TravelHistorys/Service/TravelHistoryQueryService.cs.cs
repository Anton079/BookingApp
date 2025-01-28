using Booking_App.TravelHistorys.Models;
using Booking_App.TravelHistorys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.TravelHistorys.Service
{
    public class TravelHistoryQueryService : ITravelHistoryQueryService
    {
        private readonly ITravelHistoryRepository _travelHistoryRepository;

        public TravelHistoryQueryService(ITravelHistoryRepository travelHistoryRepository)
        {
            _travelHistoryRepository = travelHistoryRepository;
        }

        public List<TravelHistory> GetAllTravelHistories()
        {
            return _travelHistoryRepository.GetAll();
        }

        public TravelHistory GetTravelHistoryById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidTravelHistoryIdException();
            }

            return _travelHistoryRepository.FindById(id);
        }

    }
}
