using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App
{
    public class User
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _phone;

        public User(string proprietati)
        {
            string[] token = proprietati.Split(',');

            _id = int.Parse(token[0]);
            _firstName = token[1];
            _lastName = token[2];
            _email = token[3];
            _password = token[4];
            _phone = token[5];
        }

        public User(int id, string firstName, string lastName, string email, string password, string phone)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _phone = phone;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public override string ToString()
        {
            return $"{Id},{FirstName},{LastName},{Email},{Password},{Phone}";
        }

        public override bool Equals(object? obj)
        {
            User user = obj as User;
            return _id == user._id;
        }

        public virtual string ToSave()
        {
            return $"{Id},{FirstName},{LastName},{Email},{Password},{Phone}";
        }
    }

}
