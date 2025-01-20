using Booking_App.Customers.Exceptions;
using Booking_App.Customers.Models;
using Booking_App.Propertys.Exceptions;
using Booking_App.Propertys.Models;
using Booking_App.Propertys.Service;
using Booking_App.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App
{
    public class ViewCustomer
    {
        private Customer _customer;
        private IPropertyQueryService _propertyQueryService;


        public ViewCustomer(Customer customer, IPropertyQueryService propertyQueryService)
        {
            _customer = customer;
            _propertyQueryService = propertyQueryService;

        }

        public void MeniuView()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("        MENIU CLIENT       ");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Afisare proprietati disponibile");
            Console.WriteLine("2. Cauta o proprietate dupa nume");
            Console.WriteLine("3. Filtrare proprietati dupa pret");
            Console.WriteLine("4. Rezerva o proprietate");
            Console.WriteLine("5. Vizualizeaza rezervarile mele");
            Console.WriteLine("6. Iesire");
            Console.WriteLine("=========================");
        }

        public void Play()
        {
            bool running = true;

            while (running)
            {
                try
                {
                    MeniuView();
                    string alegere = Console.ReadLine()?.Trim();

                    switch (alegere)
                    {
                        case "1":
                            AfisareProprietati();
                            break;
                        case "2":
                            SearchProperty();
                            break;
                        case "3":
                            FilterPropertiesByPrice();
                            break;
                        case "4":
                            BookProperty();
                            break;
                        case "5":
                            //ViewReservations();
                            break;
                        case "6":
                            Console.WriteLine("La revedere!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Optiune invalida. Incercati din nou.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
            }
        }

        public void AfisareProprietati()
        {
            try
            {
                Console.WriteLine("PROPRIETATI DISPONIBILE");
                List<Property> properties = _propertyQueryService.GetAllProperties();

                foreach (Property property in properties)
                {
                    Console.WriteLine($"ID: {property.Id} | Nume: {property.Type} | Locatie: {property.Address} | Pret pe noapte: {property.PricePerNight} | Disponibil: {property.Availability}");
                }
                Console.WriteLine("=========================");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SearchProperty()
        {
            try
            {
                Console.WriteLine("Introduceti numele sau un cuvant cheie pentru a cauta o proprietate: ");
                string searchTerm = Console.ReadLine().ToLower();

                List<Property> properties = _propertyQueryService.GetAllProperties();
                List<Property> filteredProperties = new List<Property>();

                foreach (Property property in properties)
                {
                    if (property.Type.ToLower().Contains(searchTerm) || property.Description.ToLower().Contains(searchTerm))
                    {
                        filteredProperties.Add(property);
                    }
                }

                if (filteredProperties.Count == 0)
                {
                    Console.WriteLine("Nu s-au gasit proprietati care sa corespunda cautarii.");
                    return;
                }

                Console.WriteLine("Proprietati gasite: ");
                foreach (Property property in filteredProperties)
                {
                    Console.WriteLine($"ID: {property.Id} | Nume: {property.Type} | Locatie: {property.Address} | Pret: {property.PricePerNight}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FilterPropertiesByPrice()
        {
            try
            {
                Console.WriteLine("Introduceti pretul maxim pe noapte:");
                int maxPrice = int.Parse(Console.ReadLine());

                List<Property> properties = _propertyQueryService.GetPropertiesByMaxPrice(maxPrice);

                if (properties.Count == 0)
                {
                    Console.WriteLine("Nu s-au gasit proprietati in aceasta gama de pret.");
                    return;
                }

                Console.WriteLine("Proprietati disponibile in aceasta gama de pret:");
                foreach (Property property in properties)
                {
                    Console.WriteLine($"ID: {property.Id} | Nume: {property.Type} | Pret: {property.PricePerNight} | Locatie: {property.Address}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void BookProperty()
        {
            try
            {
                Console.WriteLine("Introduceti ID-ul proprietatii pe care doriti sa o rezervati:");
                int propertyId = int.Parse(Console.ReadLine());

                Console.WriteLine("Introduceti data de inceput (YYYY-MM-DD):");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Introduceti data de sfarsit (YYYY-MM-DD):");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                //_reservationCommandService.(_customer.Id, propertyId, startDate, endDate);
                Console.WriteLine("Rezervare efectuata cu succes!");
            }
            catch (PropertyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare la rezervare: {ex.Message}");
            }
        }
    }
}
