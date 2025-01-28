using Booking_App.TravelHistorys.Models;
using Booking_App.TravelHistorys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.TravelHistorys.Service
{
    public class TravelHistoryCommandService : ITravelHistoryCommandService
    {
        private readonly ITravelHistoryRepository _travelHistoryRepository;

        public TravelHistoryCommandService(ITravelHistoryRepository travelHistoryRepository)
        {
            _travelHistoryRepository = travelHistoryRepository;
        }

        public TravelHistory AddTravelHistory(TravelHistory travelHistory)
        {
            if (travelHistory == null)
            {
                throw new NullTravelHistoryException();
            }

            return _travelHistoryRepository.AddTravelHistory(travelHistory);
        }

        public void RemoveTravelHistory(int id)
        {
            if (id <= 0)
            {
                throw new InvalidTravelHistoryIdException();
            }

            _travelHistoryRepository.Remove(id);
        }

        public TravelHistory UpdateTravelHistory(int id, TravelHistory travelHistory)
        {
            if (id <= 0)
            {
                throw new InvalidTravelHistoryIdException();
            }

            if (travelHistory == null)
            {
                throw new NullTravelHistoryException();
            }

            return _travelHistoryRepository.UpdateTravelHistory(id, travelHistory);
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 100000);

            while(_travelHistoryRepository.FindById(id) != null)
            {
                id = rand.Next(1, 10000);
            }

            return id;
        }
    }
}
