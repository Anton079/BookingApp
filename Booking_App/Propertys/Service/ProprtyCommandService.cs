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

        public Property AddProperty(Property property)
        {
            if (property == null)
            {
                throw new NullPropertyException();
            }
            property.Id = _propertyRepository.GenerateId();
            return _propertyRepository.AddProperty(property);
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
