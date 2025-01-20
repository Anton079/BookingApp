using Booking_App.Propertys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Propertys.Service
{
    public interface IPropertyQueryService
    {
        List<Property> GetAllProperties();
        Property GetPropertyById(int id);
        List<Property> GetAvailableProperties();
        List<Property> GetPropertiesByMaxPrice(int maxPrice);
    }
}
