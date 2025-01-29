using Booking_App.Propertys.Exceptions;
using Booking_App.Propertys.Models;
using Booking_App.Propertys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Propertys.Service
{
    public class PropertyCommandService : IPropertyCommandService
    {
        private IPropertyRepository _propertyRepository;

        public PropertyCommandService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public Property AddProperty(string propertyType, string newAdress, string descriere, int nrPaturi, int newRoomCount, int newGuestCount, int pricePerNight,
                bool isAvailable, double newRating, int newChecIng, int newCheckOut)
        {
            int idGenerate = _propertyRepository.GenerateId();
            Property propertyNew = new Property(idGenerate, propertyType, newAdress, descriere, nrPaturi, newRoomCount, newGuestCount, pricePerNight,
                isAvailable, newRating, newChecIng, newCheckOut);

            if (propertyNew == null)
            {
                throw new NullPropertyException();
            }
            return _propertyRepository.AddProperty(propertyNew);
        }

        public Property UpdateProperty(int id, Property updatedProperty)
        {
            if (updatedProperty == null)
            {
                throw new NullPropertyException();
            }

            Property existingProperty = _propertyRepository.FindById(id);
            if (existingProperty == null)
            {
                throw new PropertyNotFoundException();
            }

            return _propertyRepository.UpdateProperty(id, updatedProperty);
        }

        public int RemoveProperty(int id)
        {
            Property removedProperty = _propertyRepository.Remove(id);
            if (removedProperty == null)
            {
                throw new PropertyNotFoundException();
            }
            return id;
        }
    }
}
