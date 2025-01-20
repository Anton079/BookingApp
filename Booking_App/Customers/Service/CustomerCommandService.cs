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
    public class CustomerCommandService : ICustomerCommandService
    {
        private ICustomerRepository _customerRepository;

        public CustomerCommandService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new NullCustomerException();
            }
            customer.Id = _customerRepository.GenerateId();
            return _customerRepository.AddCustomer(customer);
        }

        public Customer UpdateCustomer(int id, Customer updatedCustomer)
        {
            if (updatedCustomer == null)
            {
                throw new NullCustomerException();
            }

            Customer existingCustomer = _customerRepository.FindById(id);
            if (existingCustomer == null)
            {
                throw new CustomerNotFoundException();
            }

            return _customerRepository.UpdateCustomer(id, updatedCustomer);
        }

        public int RemoveCustomer(int id)
        {
            Customer removedCustomer = _customerRepository.Remove(id);
            if (removedCustomer == null)
            {
                throw new CustomerNotFoundException();
            }
            return id;
        }
    }
}
