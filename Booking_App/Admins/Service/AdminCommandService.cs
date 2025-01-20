using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking_App.Admins.Exceptions;
using Booking_App.Admins.Models;
using Booking_App.Admins.Repository;

namespace Booking_App.Admins.Service
{
    public class AdminCommandService : IAdminCommandService
    {
        private IAdminRepository _adminRepository;

        public AdminCommandService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin AddAdmin(Admin admin)
        {
            if (admin == null)
            {
                throw new NullAdminException();
            }
            _adminRepository.AddAdmin(admin);
            return admin;
        }

        public int RemoveAdmin(int id)
        {
            if (id == -1)
            {
                throw new AdminNotFoundException();
            }
            _adminRepository.Remove(id);
            return id;
        }

        public Admin UpdateAdmin(int id, Admin admin)
        {
            if (id == -1)
            {
                throw new AdminNotFoundException();
            }
            if (admin == null)
            {
                throw new NullAdminException();
            }
            _adminRepository.UpdateAdmin(id, admin);
            return admin;
        }
    }
}

