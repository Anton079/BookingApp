﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.Admins.Models
{
    public class Admin : User
    {
        public Admin(string proprietati) : base(proprietati) { }

        public Admin(int id, string firstName, string lastName, string email, string password, string phone)
            : base(id, firstName, lastName, email, password, phone)
        {

        }

        public override string ToSave()
        {
            return base.ToSave();
        }

        public override bool Equals(object? obj)
        {
            Admin admin = obj as Admin;
            return Id == admin.Id;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
