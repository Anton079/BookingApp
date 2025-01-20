using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Booking_App.Admins.Models;

namespace Booking_App.Admins.Service
{
    public interface IAdminQueryService
    {
        List<Admin> GetAllAdmins();

        Admin FindAdminById(int id);
    }
}

