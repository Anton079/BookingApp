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
    public class PropertyQueryService : IPropertyQueryService
    {
        private IPropertyRepository _propertyRepository;

        public PropertyQueryService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public List<Property> GetAllProperties()
        {
            return _propertyRepository.GetAll();
        }

        public Property GetPropertyById(int id)
        {
            Property property = _propertyRepository.FindById(id);
            if (property == null)
            {
                throw new PropertyNotFoundException();
            }
            return property;
        }

        public List<Property> GetAvailableProperties()
        {
            List<Property> availableProperties = new List<Property>();
            List<Property> allProperties = _propertyRepository.GetAll();
            for (int i = 0; i < allProperties.Count; i++)
            {
                if (allProperties[i].Availability)
                {
                    availableProperties.Add(allProperties[i]);
                }
            }
            return availableProperties;
        }

        public List<Property> GetPropertiesByMaxPrice(int maxPrice)
        {
            List<Property> filteredProperties = new List<Property>();
            List<Property> allProperties = _propertyRepository.GetAll();
            for (int i = 0; i < allProperties.Count; i++)
            {
                if (allProperties[i].PricePerNight <= maxPrice)
                {
                    filteredProperties.Add(allProperties[i]);
                }
            }
            return filteredProperties;
        }
    }
}
