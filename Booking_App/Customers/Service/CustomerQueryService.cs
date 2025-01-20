using Booking_App.Customers.Exceptions;
using Booking_App.Customers.Models;
using Booking_App.Customers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Customers.Service
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private ICustomerRepository _customerRepository;

        public CustomerQueryService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = _customerRepository.FindById(id);
            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }
            return customer;
        }

        public List<Customer> GetCustomersByMembershipLevel(int membershipLevel)
        {
            List<Customer> filteredCustomers = new List<Customer>();
            List<Customer> allCustomers = _customerRepository.GetAll();
            for (int i = 0; i < allCustomers.Count; i++)
            {
                if (allCustomers[i].MembershipLevel == membershipLevel)
                {
                    filteredCustomers.Add(allCustomers[i]);
                }
            }
            return filteredCustomers;
        }
    }
}
