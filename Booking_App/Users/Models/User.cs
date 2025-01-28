using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Users.Models
{
    public class User
    {
        private int _id;
        private string _type;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private int _phone;

        public User(string proprietati)
        {
            string[] token = proprietati.Split(',');

            _id = int.Parse(token[0]);
            _type = token[1];
            _firstName = token[2];
            _lastName = token[3];
            _email = token[4];
            _password = token[5];
            _phone = int.Parse(token[6]);
        }

        public User(int id, string type, string firstName, string lastName, string email, string password, int phone)
        {
            _id = id;
            _type = type;
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

        public string Type
        {
            get { return _type; }
            set { _type = value; }
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

        public int Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public override string ToString()
        {
            return $"{Id},{Type},{FirstName},{LastName},{Email},{Password},{Phone}";
        }

        public override bool Equals(object? obj)
        {
            User user = obj as User;
            return _id == user._id;
        }

        public virtual string ToSave()
        {
            return $"{Id},{Type},{FirstName},{LastName},{Email},{Password},{Phone}";
        }

        public string UserInfo()
        {
            string text = " ";
            text += "ID: " + _id + "\n";
            text += "Type: " + _type + "\n";
            text += "First Name: " + _firstName + "\n";
            text += "Last Name: " + _lastName + "\n";
            text += "Email: " + _email + "\n";
            text += "Password: " + _password + "\n";
            text += "Phone: " + _phone + "\n";
            return text;
        }

    }

}
