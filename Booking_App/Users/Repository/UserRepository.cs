using Booking_App.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> userList;

        public UserRepository()
        {
            userList = new List<User>();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetFilePath()))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string type = line.Split(',')[1];

                        switch (type)
                        {
                            case "Admin": userList.Add(new Admin(line)); break;
                            case "Customer": userList.Add(new Customer(line)); break;

                            default:break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "User");

            return file;
        }

        private void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetFilePath()))
                {
                    sw.WriteLine(ToSaveAll());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string ToSaveAll()
        {
            string save = "";
            for (int i = 0; i < userList.Count; i++)
            {
                save += userList[i].ToSave();
                if (i < userList.Count - 1)
                {
                    save += "\n";
                }
            }
            return save;
        }

        public List<User> GetAll()
        {
            return userList;
        }

        public User AddUser(User user)
        {
            userList.Add(user);
            SaveData();
            return user;
        }

        public User Remove(int id)
        {
            User user = FindById(id);

            userList.Remove(user);
            SaveData();
            return user;
        }

        public User FindById(int id)
        {
            foreach (User user in userList)
            {
                if (user.Id != id)
                {
                    return user;
                }
            }
            return null;
        }

        public User UpdateUser(int id, User user)
        {
            User userToUpdate = FindById(id);

            if (userToUpdate is Customer customerToUpdate && user is Customer customer)
            {
                userToUpdate.FirstName = customer.FirstName;
                userToUpdate.LastName = customer.LastName;
                userToUpdate.Email = customer.Email;
                userToUpdate.Password = customer.Password;
                userToUpdate.Phone = customer.Phone;
                customerToUpdate.PreferredPaymentMethod = customer.PreferredPaymentMethod;
                customerToUpdate.MembershipLevel = customer.MembershipLevel;
            }
            else if (userToUpdate is Admin adminToUpdate && user is Admin admin)
            {
                adminToUpdate.FirstName = admin.FirstName;
                adminToUpdate.LastName = admin.LastName;
                adminToUpdate.Email = admin.Email;
                adminToUpdate.Password = admin.Password;
                adminToUpdate.Phone = admin.Phone;
            }

            SaveData();
            return userToUpdate;
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(0, 1000000);

            while (FindById(id) != null)
            {
                id = rand.Next(0, 1000000);
            }
            return id;
        }
    }
}
