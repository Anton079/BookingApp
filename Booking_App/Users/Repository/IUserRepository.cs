using Booking_App.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Users.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User AddUser(User user);
        User Remove(int id);
        User FindById(int id);
        User UpdateUser(int id, User user);
        int GenerateId();
    }
}
