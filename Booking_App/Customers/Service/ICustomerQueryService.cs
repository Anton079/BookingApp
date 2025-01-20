using Booking_App.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Customers.Service
{
    public interface ICustomerQueryService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        List<Customer> GetCustomersByMembershipLevel(int membershipLevel);
    }
}
