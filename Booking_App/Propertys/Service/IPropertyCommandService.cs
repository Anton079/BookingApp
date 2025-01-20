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
        Property AddProperty(Property property);
        Property UpdateProperty(int id, Property updatedProperty);
        int RemoveProperty(int id);
    }
}
