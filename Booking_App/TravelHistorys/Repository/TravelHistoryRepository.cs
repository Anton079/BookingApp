using Booking_App.TravelHistorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_App.TravelHistorys.Repository
{
    public class TravelHistoryRepository : ITravelHistoryRepository
    {
        private List<TravelHistory> travelHistoryList;

        public TravelHistoryRepository()
        {
            travelHistoryList = new List<TravelHistory>();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetFilePath()))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        TravelHistory travelHistory = new TravelHistory(line);
                        travelHistoryList.Add(travelHistory);
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

            string file = Path.Combine(folder, "TravelHistory");

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
            for (int i = 0; i < travelHistoryList.Count; i++)
            {
                save += travelHistoryList[i].ToString();
                if (i < travelHistoryList.Count - 1)
                {
                    save += "\n";
                }
            }
            return save;
        }

        public List<TravelHistory> GetAll()
        {
            return travelHistoryList;
        }

        public TravelHistory AddTravelHistory(TravelHistory travelHistory)
        {
            travelHistoryList.Add(travelHistory);
            SaveData();
            return travelHistory;
        }

        public TravelHistory Remove(int id)
        {
            TravelHistory history = FindById(id);
            if (history != null)
            {
                travelHistoryList.Remove(history);
                SaveData();
            }
            return history;
        }

        public TravelHistory FindById(int id)
        {
            foreach (TravelHistory history in travelHistoryList)
            {
                if (history.Id == id)
                {
                    return history;
                }
            }
            return null;
        }

        public TravelHistory UpdateTravelHistory (int id, TravelHistory travelHistory)
        {
            TravelHistory existingTravelHistory = FindById(id);

            if (existingTravelHistory != null)
            {
                existingTravelHistory.CustomerId = travelHistory.CustomerId;
                existingTravelHistory.PropertyId = travelHistory.PropertyId;
                existingTravelHistory.StartDate = travelHistory.StartDate;
                existingTravelHistory.EndDate = travelHistory.EndDate;

                SaveData();
            }

            return existingTravelHistory;
        }

    }
}
