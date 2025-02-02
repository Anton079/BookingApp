﻿using Booking_App.Propertys.Repository;
using Booking_App.Propertys.Service;
using Booking_App.TravelHistorys.Service;
using Booking_App.Users.Exceptions;
using Booking_App.Users.Models;
using Booking_App.Users.Repository;
using Booking_App.Users.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App
{
    public class ViewLogin
    {
        private IPropertyQueryService _propertyQueryService;
        private IPropertyCommandService _propertyCommandService;
        private ITravelHistoryCommandService _travelHistoryCommandService;
        private ITravelHistoryQueryService _travelHistoryQueryService;
        private IUserQueryService _userQueryService;
        private IUserCommandService _userCommandService;

        public ViewLogin(IPropertyCommandService propertyCommandService, IUserCommandService userCommandService, IUserQueryService userQueryService, IPropertyQueryService propertyQueryService, ITravelHistoryCommandService travelHistoryCommandService, 
            ITravelHistoryQueryService travelHistoryQueryService)
        {
            _userQueryService = userQueryService;
            _userCommandService = userCommandService;

            _propertyQueryService = propertyQueryService;
            _propertyCommandService = propertyCommandService;

            _travelHistoryCommandService = travelHistoryCommandService;
            _travelHistoryQueryService = travelHistoryQueryService;
        }

        public void LoginMeniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru logare");
            Console.WriteLine("Apasati tasta 2 pentru a va inregistra");
            Console.WriteLine("Apasati tasta 3 pentru a reseta parola");
        }

        public void Play()
        {
            bool running = true;
            while (running)
            {
                LoginMeniu();
                string alegere = Console.ReadLine();
                switch(alegere)
                {
                    case "1":
                        Login();
                        break;

                    case "2":
                        NewRegistration();
                        break;

                    case "3":
                        ResetareParola();
                        break;

                    default:
                        Console.WriteLine("Optiune invalida. Reincercati.");
                        break;
                }
            }
        }

        public void Login()
        {
            Console.WriteLine("Introduce ti id ul!");
            int idLogin = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduce ti parola");
            string parolaLogin = Console.ReadLine();

            try
            {
                User user = _userQueryService.FindUserById(idLogin);

                switch (user.Type)
                {
                    case "Admin":
                        if (user is Admin admin)
                        {
                            ViewAdmin viewAdmin = new ViewAdmin(admin, _userCommandService, 
                                _userQueryService, _propertyQueryService, _propertyCommandService);

                            viewAdmin.Play();
                        }
                        break;

                    case "Customer":
                        if (user is Customer customer)
                        {
                            ViewCustomer viewCustomer = new ViewCustomer(customer,
                                _propertyQueryService,
                                _travelHistoryCommandService,
                                _travelHistoryQueryService);

                            viewCustomer.Play();
                        }
                        break;

                    default:
                        Console.WriteLine("Tip utilizator necunoscut.");
                        break;
                }
            }catch (UserNotFoundException ex) { Console.WriteLine(ex.Message); return; }
        }

        public void NewRegistration()
        {
            Console.WriteLine("Selectati tipul de utilizator pentru inregistrare: Admin sau Customer");
            string tip = Console.ReadLine().ToLower();

            switch (tip)
            {
                case "admin":
                    RegisterAdmin();
                    break;

                case "customer":
                    RegisterCustomer();
                    break;

                default:
                    Console.WriteLine("Tip utilizator invalid.");
                    break;
            }
        }

        private void RegisterAdmin()
        {

            Console.WriteLine("Introduceti numele de utilizator:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Introduceti numele complet:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Introduceti emailul:");
            string email = Console.ReadLine();

            Console.WriteLine("Introduceti parola:");
            string password = Console.ReadLine();

            Console.WriteLine("Introduceti numarul de telefon:");
            int phone = Int32.Parse(Console.ReadLine());

            string type = "Admin";

            try
            {
                _userCommandService.RegisterAdmin(type, firstName, lastName, email, password, phone);
                Console.WriteLine($"Admin înregistrat cu succes!");
            }
            catch (NullAdminException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RegisterCustomer()
        {
            string type = "Customer";

            Console.WriteLine("Introduceti numele de utilizator:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Introduceti numele complet:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Introduceti emailul:");
            string email = Console.ReadLine();

            Console.WriteLine("Introduceti parola:");
            string password = Console.ReadLine();

            Console.WriteLine("Introduceti nr de telefon:");
            int phone = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti metoda de plata:");
            string preferredPaymentMethod = Console.ReadLine();

            Console.WriteLine("De acum ai membership level 1, la primele doua achizitii de pe booking, vei avea level 2!");

            try
            {
                _userCommandService.RegisterCustomer(type, firstName, lastName, email, password, phone, preferredPaymentMethod);
                Console.WriteLine("Client înregistrat cu succes!");
            }
            catch (NullCustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ResetareParola()
        {
            Console.WriteLine("Introduceti tipul de utilizator (Admin, Client):");
            string tip = Console.ReadLine().ToLower();

            Console.WriteLine("Introduceti ID-ul:");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti noua parola:");
            string parolaNoua = Console.ReadLine();

            switch (tip)
            {
                case "Admin":
                    try
                    {
                        Admin admin = (Admin)_userQueryService.FindUserById(id);
                        if (admin != null)
                        {
                            admin.Password = parolaNoua;
                            _userCommandService.UpdateUser(id, admin);
                            Console.WriteLine("Parola actualizată cu succes pentru Admin.");
                        }
                        else
                        {
                            Console.WriteLine("Adminul nu a fost găsit.");
                        }
                    }
                    catch (AdminNotFoundException ex) { Console.WriteLine(ex.Message); }
                    catch (NullAdminException ex) { Console.WriteLine(ex.Message); }
                    break;

                case "Customer":
                    try
                    {
                        Customer customer = (Customer)_userQueryService.FindUserById(id);
                        if (customer != null)
                        {
                            customer.Password = parolaNoua;
                            _userCommandService.UpdateUser(id, customer);
                            Console.WriteLine("Parola actualizată cu succes pentru Client.");
                        }
                        else
                        {
                            Console.WriteLine("Clientul nu a fost găsit.");
                        }
                    }
                    catch (CustomerNotFoundException ex) { Console.WriteLine(ex.Message); }
                    catch (NullCustomerException ex) { Console.WriteLine(ex.Message); }
                    break;
            }

        }
    }
}
