using Booking_App.Propertys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Booking_App.Propertys.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private List<Property> propertyList;

        public PropertyRepository()
        {
            propertyList = new List<Property>();
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
                        Property property = new Property(line);
                        propertyList.Add(property);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folder = Path.Combine(currentDirectory, "data");
            string file = Path.Combine(folder, "Property");
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
                Console.WriteLine(ex.Message);
            }
        }

        public string ToSaveAll()
        {
            string save = "";
            for (int i = 0; i < propertyList.Count; i++)
            {
                save += propertyList[i].ToString();
                if (i < propertyList.Count - 1)
                {
                    save += "\n";
                }
            }
            return save;
        }

        // CRUD Operations

        public List<Property> GetAll()
        {
            return propertyList;
        }

        public Property AddProperty(Property property)
        {
            propertyList.Add(property);
            SaveData();
            return property;
        }

        public Property Remove(int id)
        {
            Property property = FindById(id);
            if (property != null)
            {
                propertyList.Remove(property);
                SaveData();
            }
            return property;
        }

        public Property FindById(int id)
        {
            if (id != -1)
            {
                foreach (Property property in propertyList)
                {
                    if (property.Id == id)
                    {
                        return property;
                    }
                }
            }
            return null;
        }

        public Property UpdateProperty(int id, Property updatedProperty)
        {
            Property existingProperty = FindById(id);
            if (existingProperty != null)
            {
                existingProperty.Type = updatedProperty.Type;
                existingProperty.Address = updatedProperty.Address;
                existingProperty.Description = updatedProperty.Description;
                existingProperty.BedCount = updatedProperty.BedCount;
                existingProperty.RoomCount = updatedProperty.RoomCount;
                existingProperty.MaxGuests = updatedProperty.MaxGuests;
                existingProperty.PricePerNight = updatedProperty.PricePerNight;
                existingProperty.Availability = updatedProperty.Availability;
                existingProperty.Rating = updatedProperty.Rating;
                existingProperty.CheckInTime = updatedProperty.CheckInTime;
                existingProperty.CheckOutTime = updatedProperty.CheckOutTime;

                SaveData();
            }
            return existingProperty;
        }

        public int GenerateId()
        {
            Random rand = new Random();
            int id = rand.Next(1, 1000000);
            while (FindById(id) != null)
            {
                id = rand.Next(1, 1000000);
            }
            return id;
        }
    }
}
