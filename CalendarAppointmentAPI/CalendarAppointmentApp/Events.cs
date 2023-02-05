using CalendarEvents.Models;
using System.Collections.Generic;

namespace CalendarEvents.CalendarAppointmentApp
{
    
    public class Events
    {
        public static List<CalendarEvent> eventDetails = new List<CalendarEvent>()
        {
             new CalendarEvent(){
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 26, 10, 30, 00),
                endTime = new DateTime(2023, 1, 26, 11, 30, 00),
                label = "gray",
                status = "Scheduled"
            },
            new CalendarEvent(){
                eventId = new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"),
                title = "Team-building meeting",
                addDescription =  "Improving trust among teammates, Helping the group feel valued ", 
                startTime = new DateTime(2023, 1, 27, 12, 30, 00),
                endTime = new DateTime(2023, 1, 27, 13, 30, 00),
                label = "red",
                status = "Scheduled"
            },
            new CalendarEvent(){
                eventId = new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"),
                title = "Townhall",
                addDescription =  "Town hall meeting is a company's management to meet and connect with their employees", 
                startTime = new DateTime(2023, 1, 28, 14, 30, 00),
                endTime = new DateTime(2023, 1, 28, 15, 30, 00),
                label = "green",
                status = "Scheduled"
            },
            new CalendarEvent(){
                eventId = new Guid("f4ce1eeb-4ba7-44df-82f2-86c519bcceed"),
                title = "Status update meeting",
                addDescription =  "progress checks, check-in meetings, and stand-ups", 
                startTime = new DateTime(2023, 1, 25, 10, 30, 00),
                endTime = new DateTime(2023, 1, 25, 11, 30, 00),
                label = "blue",
                status = "Scheduled"
            },
            new CalendarEvent(){
                eventId = new Guid("a016e5f4-7650-439d-8caf-41e433dfc89a"),
                title = "Problem-solving meeting",
                addDescription =  "Helping you bring different types of expertise and ideas together.", 
                startTime = new DateTime(2023, 1, 30, 14, 30, 00),
                endTime = new DateTime(2023, 1, 30, 15, 30, 00),
                label = "indigo",
                status = "Scheduled"
            },
            
            new CalendarEvent(){
                eventId = new Guid("ebbe2d4b-1d6b-420d-8e46-3d61a2b4476e"),
                title = "One-on-one meeting",
                addDescription =  " A meeting is about a performance review ", 
                startTime = new DateTime(2023, 1, 31, 10, 30, 00),
                endTime = new DateTime(2023, 1, 31, 11, 30, 00),
                label = "purple",
                status = "Scheduled"
            },
            new CalendarEvent(){
                eventId = new Guid("0cc49aab-96b0-4186-b508-09e016006d10"),
                title = "Check-in meeting",
                addDescription =  "The meeting is used to monitor task progress against an expected outcome.", 
                startTime = new DateTime(2023, 1, 25, 12, 30, 00),
                endTime = new DateTime(2023, 1, 25, 13, 30, 00),
                label = "gray",
                status = "Cancelled"
            },
            new CalendarEvent(){
                eventId = new Guid("feab3d1f-4416-438e-b800-ee1026fbe1d1"),
                title = "Disprz book club",
                addDescription =  "share opinions or explore deeper meanings of the book you are reading", 
                startTime = new DateTime(2023, 1, 25, 17, 30, 00),
                endTime = new DateTime(2023, 1, 25, 18, 30, 00),
                label = "red",
                status = "Scheduled"
            },
        };
            
    }
} 




























// public Dictionary<Guid, CalendarEvent> EventsInformation()
//         {
//             CalendarEvent decisionMakingMeeting = new CalendarEvent(){
//                 title = "Decision-making meeting",
//                 addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
//                 startTime = new DateTime(2023, 1, 26, 10, 30, 00),
//                 endTime = new DateTime(2023, 1, 26, 11, 30, 00),
//                 label = "gray"
//             };
//             CalendarEvent teamBuildingMeeting = new CalendarEvent(){
//                 title = "Team-building meeting",
//                 addDescription =  "Improving trust among teammates, Helping the group feel valued ", 
//                 startTime = new DateTime(2023, 1, 27, 12, 30, 00),
//                 endTime = new DateTime(2023, 1, 27, 13, 30, 00),
//                 label = "red"
//             };
//             CalendarEvent townhall = new CalendarEvent(){
//                 title = "Townhall",
//                 addDescription =  "Town hall meeting is a company's management to meet and connect with their employees", 
//                 startTime = new DateTime(2023, 1, 28, 14, 30, 00),
//                 endTime = new DateTime(2023, 1, 28, 15, 30, 00),
//                 label = "green"
//             };
//             CalendarEvent statusUpdateMeeting = new CalendarEvent(){
//                 title = "Status update meeting",
//                 addDescription =  "progress checks, check-in meetings, and stand-ups", 
//                 startTime = new DateTime(2023, 1, 25, 10, 30, 00),
//                 endTime = new DateTime(2023, 1, 25, 11, 30, 00),
//                 label = "blue"
//             };
//             CalendarEvent problemSolvingMeeting = new CalendarEvent(){
//                 title = "Problem-solving meeting",
//                 addDescription =  "Helping you bring different types of expertise and ideas together.", 
//                 startTime = new DateTime(2023, 1, 30, 14, 30, 00),
//                 endTime = new DateTime(2023, 1, 30, 15, 30, 00),
//                 label = "indigo"
//             };
            
//             CalendarEvent oneOnOneMeeting = new CalendarEvent(){
//                 title = "One-on-one meeting",
//                 addDescription =  " A meeting is about a performance review ", 
//                 startTime = new DateTime(2023, 1, 31, 10, 30, 00),
//                 endTime = new DateTime(2023, 1, 31, 11, 30, 00),
//                 label = "purple"
//             };
//             CalendarEvent checkInMeeting  = new CalendarEvent(){
//                 title = "Check-in meeting",
//                 addDescription =  "The meeting is used to monitor task progress against an expected outcome.", 
//                 startTime = new DateTime(2023, 1, 25, 12, 30, 00),
//                 endTime = new DateTime(2023, 1, 25, 13, 30, 00),
//                 label = "gray"
//             };
//             CalendarEvent disprzBookClub = new CalendarEvent(){
//                 title = "Disprz book club",
//                 addDescription =  "share opinions or explore deeper meanings of the book you are reading", 
//                 startTime = new DateTime(2023, 1, 25, 17, 30, 00),
//                 endTime = new DateTime(2023, 1, 25, 18, 30, 00),
//                 label = "red"
//             };
//             Dictionary<Guid, CalendarEvent>  Events = new Dictionary<Guid, CalendarEvent>();
//             Events.Add(new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"), decisionMakingMeeting);
//             Events.Add(new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"), teamBuildingMeeting);
//             Events.Add(new Guid("00eb9b20-ff58-4351-b146-d01a70be27d1"), townhall);
//             Events.Add(new Guid("f4ce1eeb-4ba7-44df-82f2-86c519bcceed"), statusUpdateMeeting);
//             Events.Add(new Guid("a016e5f4-7650-439d-8caf-41e433dfc89a"), problemSolvingMeeting);  
//             Events.Add(new Guid("ebbe2d4b-1d6b-420d-8e46-3d61a2b4476e"), oneOnOneMeeting);
//             Events.Add(new Guid("0cc49aab-96b0-4186-b508-09e016006d10"), checkInMeeting);    
//             Events.Add(new Guid("feab3d1f-4416-438e-b800-ee1026fbe1d1"), disprzBookClub);  
            
//             return Events;

//         }



