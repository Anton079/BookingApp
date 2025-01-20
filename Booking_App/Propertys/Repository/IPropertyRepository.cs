using Booking_App.Propertys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Propertys.Repository
{
    public interface IPropertyRepository
    {
        List<Property> GetAll();
        Property AddProperty(Property property);
        Property Remove(int id);
        Property FindById(int id);
        Property UpdateProperty(int id, Property updatedProperty);
        int GenerateId();
    }
}
