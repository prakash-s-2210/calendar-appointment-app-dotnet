using CalendarEvents.Models;
namespace CalendarEvents.CalendarAppointmentApp
{
    public class UsersEventsId
    {
        Events events = new Events();
        Users users = new Users();
        
        public static Dictionary<Guid, List<Guid>> usersEventsInformation = new Dictionary<Guid, List<Guid>>();
        List<Guid> eventIdList = new List<Guid>();
            
        public static List<Guid> prakashEventsIdList = new List<Guid>()
        {
            new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
            new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
            new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
            new Guid("f4ce1eeb-4ba7-44df-82f2-86c519bcceed"),
            new Guid("a016e5f4-7650-439d-8caf-41e433dfc89a")
        };
        public static List<Guid> santhoshEventsIdList = new List<Guid>(){
            new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
            new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
            new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
            new Guid("ebbe2d4b-1d6b-420d-8e46-3d61a2b4476e"),
            new Guid("0cc49aab-96b0-4186-b508-09e016006d10")
        };
        public static List<Guid> makeshEventsIdList = new List<Guid>()
        {
            new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
            new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
            new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
            new Guid("feab3d1f-4416-438e-b800-ee1026fbe1d1"),
            new Guid("f4ce1eeb-4ba7-44df-82f2-86c519bcceed")
        };
        public static List<Guid> jeyasuryaEventsIdList = new List<Guid>(){
            new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
            new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
            new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
            new Guid("0cc49aab-96b0-4186-b508-09e016006d10"),
            new Guid("a016e5f4-7650-439d-8caf-41e433dfc89a")
        };
        // public static List<Guid> sandyEventsIdList = new List<Guid>(){
        //     new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
        //     new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
        //     new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
        //     new Guid("ebbe2d4b-1d6b-420d-8e46-3d61a2b4476e"),
        //     new Guid("feab3d1f-4416-438e-b800-ee1026fbe1d1")
        // };
         public static List<Guid> sandyEventsIdList = new List<Guid>(){
        };
            
        public static Dictionary<Guid, List<Guid>>  usersEventsList= new Dictionary<Guid, List<Guid>>()
        {
           
        {new Guid("e0f38a81-a922-4996-ae40-e894762fd838"), prakashEventsIdList},
        {new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59"), santhoshEventsIdList},
        {new Guid("d2810ec0-ee64-4d69-b8b1-702e8b3ee591"), makeshEventsIdList},
        {new Guid("1626c368-e3ea-464f-be8c-2430a6116515"), jeyasuryaEventsIdList},
        {new Guid("6d354fb0-d6e4-4f0a-9d62-39ebd7fad1b7"), sandyEventsIdList},
        };
    }
}























// var decisionMakingEventKey = from e in eventsList
//             where e.Value.title == "Decision-making meeting" 
//             select e.Key;














//         Events events = new Events();
//         Users users = new Users();
        
//         public Dictionary<Guid, List<Guid>> usersEventsInformation(){
//             List<Guid> eventIdList = new List<Guid>();
//             var usersList = users.UserInformations();
//             var  eventsList = events.EventsInformation();
            
//             List<Guid> prakashEventsIdList = new List<Guid>(){
//                 new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
//                 new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
//                 new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
//                 new Guid("f4ce1eeb-4ba7-44df-82f2-86c519bcceed"),
//                 new Guid("a016e5f4-7650-439d-8caf-41e433dfc89a")
//             };
//             List<Guid> santhoshEventsIdList = new List<Guid>(){
//                 new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
//                 new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
//                 new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
//                 new Guid("ebbe2d4b-1d6b-420d-8e46-3d61a2b4476e"),
//                 new Guid("0cc49aab-96b0-4186-b508-09e016006d10")
//             };
//             List<Guid> makeshEventsIdList = new List<Guid>(){
//                 new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
//                 new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
//                 new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
//                 new Guid("feab3d1f-4416-438e-b800-ee1026fbe1d1"),
//                 new Guid("f4ce1eeb-4ba7-44df-82f2-86c519bcceed")
//             };
//             List<Guid> jeyasuryaEventsIdList = new List<Guid>(){
//                 new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
//                 new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
//                 new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
//                 new Guid("0cc49aab-96b0-4186-b508-09e016006d10"),
//                 new Guid("a016e5f4-7650-439d-8caf-41e433dfc89a")
//             };
//             List<Guid> sandyEventsIdList = new List<Guid>(){
//                 new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
//                 new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
//                 new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
//                 new Guid("ebbe2d4b-1d6b-420d-8e46-3d61a2b4476e"),
//                 new Guid("feab3d1f-4416-438e-b800-ee1026fbe1d1")
//             };

            
//             Dictionary<Guid, List<Guid>>  usersEventsList= new Dictionary<Guid, List<Guid>>();
           
//             usersEventsList.Add(new Guid("e0f38a81-a922-4996-ae40-e894762fd838"), prakashEventsIdList);
//             usersEventsList.Add(new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59"), santhoshEventsIdList);
//             usersEventsList.Add(new Guid("d2810ec0-ee64-4d69-b8b1-702e8b3ee591"), makeshEventsIdList);
//             usersEventsList.Add(new Guid("1626c368-e3ea-464f-be8c-2430a6116515"), jeyasuryaEventsIdList);
//             usersEventsList.Add(new Guid("6d354fb0-d6e4-4f0a-9d62-39ebd7fad1b7"), prakashEventsIdList);
            
            
//             return usersEventsList;
//         }