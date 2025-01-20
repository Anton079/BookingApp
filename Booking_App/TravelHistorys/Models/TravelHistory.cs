using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.TravelHistorys.Models
{
    public class TravelHistory
    {
        private int _id;
        private int _customerId;
        private int _propertyId;
        private DateTime _startDate;
        private DateTime _endDate;

        public TravelHistory(int id, int customerId, int propertyId, DateTime startDate, DateTime endDate)
        {
            _id = id;
            _customerId = customerId;
            _propertyId = propertyId;
            _startDate = startDate;
            _endDate = endDate;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public int PropertyId
        {
            get { return _propertyId; }
            set { _propertyId = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string ToSave()
        {
            return $"{Id},{CustomerId},{PropertyId},{StartDate:yyyy-MM-dd},{EndDate:yyyy-MM-dd}";
        }

        public override string ToString()
        {
            return $"{Id},{CustomerId},{PropertyId},{StartDate},{EndDate}";
        }
    }
}
