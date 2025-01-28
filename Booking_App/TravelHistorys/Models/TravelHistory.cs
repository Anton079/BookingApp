using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Booking_App.TravelHistorys.Models
{
    public class TravelHistory
    {
        private int _id;
        private int _customerId;
        private int _propertyId;
        private int _startDate;
        private int _endDate;

        public TravelHistory(int id, int customerId, int propertyId, int startDate, int endDate)
        {
            _id = id;
            _customerId = customerId;
            _propertyId = propertyId;
            _startDate = startDate;
            _endDate = endDate;
        }

        public TravelHistory(string proprietati)
        {
            string[] tokne = proprietati.Split(',');

            _id = int.Parse(tokne[0]);
            _customerId = int.Parse(tokne[1]);
            _propertyId = int.Parse(tokne[2]);
            _startDate = int.Parse(tokne[3]);
            _endDate = int.Parse(tokne[4]);
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

        public int StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public int EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string ToSave()
        {
            return $"{Id},{CustomerId},{PropertyId},{StartDate:yyyy-MM-dd},{EndDate:yyyy-MM-dd}";
        }

        public override bool Equals(object? obj)
        {
            TravelHistory travelHistory = obj as TravelHistory;
            return _id == travelHistory._id;
        }

        public override string ToString()
        {
            return $"{Id},{CustomerId},{PropertyId},{StartDate},{EndDate}";
        }
    }
}
