using Booking_App;
using Booking_App.Propertys.Repository;
using Booking_App.Propertys.Service;
using Booking_App.TravelHistorys.Repository;
using Booking_App.TravelHistorys.Service;
using Booking_App.Users.Models;
using Booking_App.Users.Repository;
using Booking_App.Users.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        UserCommandService userCommandService = new UserCommandService();
        UserRepository userRepository = new UserRepository();
        PropertyRepository propertyRepository = new PropertyRepository();
        TravelHistoryRepository travelHistoryRepository = new TravelHistoryRepository();

        UserQueryService userQueryService = new UserQueryService(userRepository);
        PropertyQueryService propertyQueryService = new PropertyQueryService(propertyRepository);
        PropertyCommandService propertyCommandService = new PropertyCommandService(propertyRepository);
        TravelHistoryQueryService travelHistoryQueryService = new TravelHistoryQueryService(travelHistoryRepository);
        TravelHistoryCommandService travelHistoryCommandService = new TravelHistoryCommandService(travelHistoryRepository);

        ViewLogin viewLogin = new ViewLogin( propertyCommandService,  userCommandService,  userQueryService,  propertyQueryService,  travelHistoryCommandService,travelHistoryQueryService);

        viewLogin.Play();

        //UserRepository userRepository1 = new UserRepository();
        //List<User> users = userRepository.GetAll();
        //foreach(User x in users)
        //    Console.WriteLine(x.UserInfo());


    }
}