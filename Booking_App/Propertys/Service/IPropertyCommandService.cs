using Booking_App.Propertys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Propertys.Service
{
    public interface IPropertyCommandService
    {
        Property AddProperty(string propertyType, string newAdress, string descriere, int nrPaturi, int newRoomCount, int newGuestCount, int pricePerNight,
                bool isAvailable, double newRating, int newChecIng, int newCheckOut);
        Property UpdateProperty(int id, Property updatedProperty);
        int RemoveProperty(int id);
    }
}
