using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Booking_App.Admins.Models;
using Booking_App.Admins.Repository;
using Booking_App.Admins.Exceptions;

namespace Booking_App.Admins.Service
{
    public class AdminQueryService : IAdminQueryService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminQueryService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public List<Admin> GetAllAdmins()
        {
            return _adminRepository.GetAll();
        }

        public Admin FindAdminById(int id)
        {
            Admin admin = _adminRepository.FindById(id);
            if (admin == null)
            {
                throw new AdminNotFoundException();
            }
            return admin;
        }
    }
}

