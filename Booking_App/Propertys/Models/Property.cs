using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Propertys.Models
{
    public class Property
    {
        private int _id;
        private string _type;
        private string _address;
        private string _description;
        private int _bedCount;
        private int _roomCount;
        private int _maxGuests;
        private int _pricePerNight;
        private bool _availability;
        private double _rating;
        private int _checkInTime;
        private int _checkOutTime;

        public Property(string proprietati)
        {
            string[] token = proprietati.Split(',');

            _id = int.Parse(token[0]);
            _type = token[1];
            _address = token[2];
            _description = token[3];
            _bedCount = int.Parse(token[4]);
            _roomCount = int.Parse(token[5]);
            _maxGuests = int.Parse(token[6]);
            _pricePerNight = int.Parse(token[7]);
            _availability = bool.Parse(token[8]);
            _rating = double.Parse(token[9]);
            _checkInTime = int.Parse(token[10]);
            _checkOutTime = int.Parse(token[11]);
        }

        public Property(int id, string type, string address, string description, int bedCount, int roomCount,
                        int maxGuests, int pricePerNight, bool availability, double rating,
                        int checkInTime, int checkOutTime)
        {
            _id = id;
            _type = type;
            _address = address;
            _description = description;
            _bedCount = bedCount;
            _roomCount = roomCount;
            _maxGuests = maxGuests;
            _pricePerNight = pricePerNight;
            _availability = availability;
            _rating = rating;
            _checkInTime = checkInTime;
            _checkOutTime = checkOutTime;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int BedCount
        {
            get { return _bedCount; }
            set { _bedCount = value; }
        }

        public int RoomCount
        {
            get { return _roomCount; }
            set { _roomCount = value; }
        }

        public int MaxGuests
        {
            get { return _maxGuests; }
            set { _maxGuests = value; }
        }

        public int PricePerNight
        {
            get { return _pricePerNight; }
            set { _pricePerNight = value; }
        }

        public bool Availability
        {
            get { return _availability; }
            set { _availability = value; }
        }

        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public int CheckInTime
        {
            get { return _checkInTime; }
            set { _checkInTime = value; }
        }

        public int CheckOutTime
        {
            get { return _checkOutTime; }
            set { _checkOutTime = value; }
        }

        public override string ToString()
        {
            return $"{Id},{Type},{Address},{Description},{BedCount},{RoomCount},{MaxGuests},{PricePerNight},{Availability},{Rating},{CheckInTime},{CheckOutTime}";
        }

        public override bool Equals(object? obj)
        {
            Property property = obj as Property;
            return _id == property._id;
        }

        public virtual string ToSave()
        {
            return $"{Id},{Type},{Address},{Description},{BedCount},{RoomCount},{MaxGuests},{PricePerNight},{Availability},{Rating},{CheckInTime},{CheckOutTime}";
        }

        public string PropertyInfo()
        {
            string text = " ";
            text += "ID: " + _id + "\n";
            text += "Type: " + _type + "\n";
            text += "Address: " + _address + "\n";
            text += "Description: " + _description + "\n";
            text += "Bed Count: " + _bedCount + "\n";
            text += "Room Count: " + _roomCount + "\n";
            text += "Max Guests: " + _maxGuests + "\n";
            text += "Price Per Night: " + _pricePerNight + "\n";
            text += "Availability: " + _availability + "\n";
            text += "Rating: " + _rating + "\n";
            text += "Check-in Time: " + _checkInTime + "\n";
            text += "Check-out Time: " + _checkOutTime + "\n";
            return text;
        }
    }

}
