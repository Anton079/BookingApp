using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking_App.Customers.Models;

namespace Booking_App.Customers.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();

        Customer AddCustomer(Customer customer);

        Customer Remove(int id);

        Customer FindById(int id);

        Customer UpdateCustomer(int id, Customer customer);

        int GenerateId();

    }
}
