using Booking_App.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Customers.Service
{
    public interface ICustomerCommandService
    {
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer updatedCustomer);
        int RemoveCustomer(int id);
    }
}
