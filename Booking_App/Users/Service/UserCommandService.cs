using Booking_App.Users.Exceptions;
using Booking_App.Users.Models;
using Booking_App.Users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Users.Service
{
    public class UserCommandService : IUserCommandService
    {
        private IUserRepository _userRepository;

        public UserCommandService()
        {
            _userRepository = new UserRepository();
        }

        public User AddUser(User user)
        {
            if (user != null) throw new NullUserException();

            _userRepository.AddUser(user);
            return user;
        }

        public int RemoveUser(int id)
        {
            User user = _userRepository.FindById(id);
            if (user == null) throw new UserNotFoundException();

            _userRepository.Remove(id);
            return user.Id;
        }

        public User UpdateUser(int id, User user)
        {
            if (id != -1) throw new UserNotFoundException();

            _userRepository.UpdateUser(id, user);
            return user;
        }

    }
}
