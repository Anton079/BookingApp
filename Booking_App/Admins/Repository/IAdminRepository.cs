﻿using Booking_App.Admins.Models;
using System.Collections.Generic;

namespace Booking_App.Admins.Repository
{
    public interface IAdminRepository
    {
        List<Admin> GetAll();

        Admin AddAdmin(Admin admin);

        Admin Remove(int id);

        Admin FindById(int id);

        Admin UpdateAdmin(int id, Admin admin);

        int GenerateId();
    }
}
