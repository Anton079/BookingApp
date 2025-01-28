using Booking_App.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Users.Service
{
    public interface IUserCommandService
    {
        User AddUser(User user);
        int RemoveUser(int id);
        User UpdateUser(int id, User user);
    }
}
