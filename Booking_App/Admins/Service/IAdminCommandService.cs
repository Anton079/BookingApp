using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking_App.Admins.Models;

namespace Booking_App.Admins.Service
{
    public interface IAdminCommandService
    {
        Admin AddAdmin(Admin admin);

        int RemoveAdmin(int id);

        Admin UpdateAdmin(int id, Admin admin);
    }
}
