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
    public class UserQueryService : IUserQueryService
    {
        private IUserRepository _userRepository;

        public UserQueryService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User FindUserById(int id)
        {
            User user = _userRepository.FindById(id);
            if (user == null) 
            { 
                throw new UserNotFoundException(); 
            }
            return user;
        }
    }
}
