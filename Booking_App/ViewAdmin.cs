using Booking_App.Propertys.Models;
using Booking_App.Propertys.Repository;
using Booking_App.Propertys.Service;
using Booking_App.Users.Models;
using Booking_App.Users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App
{
    public class ViewAdmin
    {
        private Admin _admin;
        private IUserRepository _userRepository;
        private IPropertyRepository _propertyRepository;

        public ViewAdmin(
            Admin admin, 
            IUserRepository userRepository,
            IPropertyRepository propertyRepository)
        {
            _admin = admin;
            _userRepository = userRepository;
            _propertyRepository = propertyRepository;
        }

        public void AdminView()
        {
            Console.WriteLine("1.Afiseaza toti Useri");
            Console.WriteLine("2.Afiseaza toate cazarile");
            Console.WriteLine("3.Management la cazari");
        }

        public void Play()
        {
            bool running = true;
            while (running)
            {
                int alegere = Int32.Parse(Console.ReadLine());
                switch(alegere)
                {
                    case 1:
                        AfisareUsers();
                        break;

                    case 2:
                        AfisareProperty();
                        break;

                    case 3:
                        ManageProperty();
                        break;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }

        public void AfisareUsers()
        {
            foreach(User x in _userRepository.GetAll())
            {
                Console.WriteLine(x.UserInfo());
            }
        }

        public void AfisareProperty()
        {
            foreach(Property x in _propertyRepository.GetAll())
            {
                Console.WriteLine(x.PropertyInfo);
            }
        }

        public void ManageProperty()
        {
            Console.WriteLine("1.Adauga o cazare");
            Console.WriteLine("2.Sterge o cazare");
            Console.WriteLine("3.Actualizeaza o cazare");

            string optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    EditProduct();
                    break;
                case "3":
                    RemoveProduct();
                    break;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }

        private void AddProduct()
        {
            int generatorId = _propertyRepository.GenerateId();

            Console.WriteLine("Ce tip este proprietatea(vila, apartament, camera de hotel)");
            string propertyType = Console.ReadLine();

            Console.WriteLine("Introduceti noua adresa:");
            string newAdress = Console.ReadLine();

            Console.WriteLine("Introduceti noua descriere:");
            string descriere = Console.ReadLine();

            Console.WriteLine("Introduceti noul nr de paturi:");
            int nrPaturi = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti noul nr de camere:");
            int newRoomCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti noul stoc:");
            int newGuestCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti noul pret pe noapte:");
            int pricePerNight = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti true sau false daca este available:");
            bool isAvailable = bool.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti noul rating:");
            double newRating = double.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti noul checkIn:");
            int newChecIng = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti noul CheckOut:");
            int newCheckOut = Int32.Parse(Console.ReadLine());

            Property newProperty = new Property(generatorId, propertyType, newAdress, descriere, nrPaturi, newRoomCount, newGuestCount, pricePerNight, 
                isAvailable, newRating, newChecIng, newCheckOut);
            _propertyRepository.AddProperty(newProperty);

            Console.WriteLine("Propietatea a fost adaugat cu succes!");

        }

        private void EditProduct()
        {
            Console.WriteLine("Introduceti ID-ul produsului pe care doriti sa il modificati:");
            int productId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ce doriti sa modificati?");
            Console.WriteLine("1. address");
            Console.WriteLine("2. Descrierea");
            Console.WriteLine("3. numarul de paturi");
            Console.WriteLine("4. numarul de camere");
            Console.WriteLine("5. numarul maxim de oaspeti");
            Console.WriteLine("6. pretul per noapte");
            Console.WriteLine("7. daca este available");
            Console.WriteLine("8. rating");
            Console.WriteLine("9. checkIn ul");
            Console.WriteLine("10. checkOut ul");
            int option = Int32.Parse(Console.ReadLine());

            Property propertyToEdit = _propertyRepository.FindById(productId);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Introduceti noua adresa:");
                    string newAdress = Console.ReadLine();
                    propertyToEdit.Address = newAdress;
                    break;

                case 2:
                    Console.WriteLine("Introduceti noua descriere:");
                    string descriere = Console.ReadLine();
                    propertyToEdit.Description = descriere;
                    break;

                case 3:
                    Console.WriteLine("Introduceti noul nr de paturi:");
                    int nrPaturi = Int32.Parse(Console.ReadLine());
                    propertyToEdit.BedCount = nrPaturi;
                    break;

                case 4:
                    Console.WriteLine("Introduceti noul nr de camere:");
                    int newRoomCount = Int32.Parse(Console.ReadLine());
                    propertyToEdit.RoomCount = newRoomCount;
                    break;

                case 5:
                    Console.WriteLine("Introduceti noul stoc:");
                    int newGuestCount = Int32.Parse(Console.ReadLine());
                    propertyToEdit.MaxGuests = newGuestCount;
                    break;

                case 6:
                    Console.WriteLine("Introduceti noul pret pe noapte:");
                    int pricePerNight = Int32.Parse(Console.ReadLine());
                    propertyToEdit.PricePerNight = pricePerNight;
                    break;

                case 7:
                    Console.WriteLine("Introduceti true sau false daca este available:");
                    bool isAvailable = bool.Parse(Console.ReadLine());
                    propertyToEdit.Availability = isAvailable;
                    break;

                case 8:
                    Console.WriteLine("Introduceti noul rating:");
                    double newRating = Int32.Parse(Console.ReadLine());
                    propertyToEdit.Rating = newRating;
                    break;

                case 9:
                    Console.WriteLine("Introduceti noul checkIn:");
                    int newChecIng = Int32.Parse(Console.ReadLine());
                    propertyToEdit.CheckInTime = newChecIng;
                    break;

                case 10:
                    Console.WriteLine("Introduceti noul CheckOut:");
                    int newCheckOut = Int32.Parse(Console.ReadLine());
                    propertyToEdit.CheckOutTime = newCheckOut;
                    break;

                default:
                    Console.WriteLine("Optiune invalida. Operatia a fost anulata.");
                    return;
            }

            _propertyRepository.UpdateProperty(productId, propertyToEdit);
            Console.WriteLine("Produsul a fost modificat cu succes!");
        }

        private void RemoveProduct()
        {
            Console.WriteLine("Introduceti ID-ul produsului pe care doriti sa il stergeti:");
            int productId = int.Parse(Console.ReadLine());

            _propertyRepository.Remove(productId);
            Console.WriteLine("Produsul a fost sters cu succes!");
        }
    }
}
