using System;
using System.Collections.Generic;
//Allare Models here
namespace DataAccessLayer
{


    public class ListAllseates
    {
        public List<ListbusSeatdetailsLower> Allseats { get; set; }
    }

    public class ListbusSeatdetailsLower
    {
        public List<busSeatdetails> S = new List<busSeatdetails>();
    }

    //for Booking seats flags O/P for UI
    public class busSeatdetails
    {
        public int SeatId { get; set; }
        public int SeatNumber { get; set; }
        public int SeatRowNumber { get; set; }
        public int BusId { get; set; }
        public string SeatType { get; set; }
        public string BookingDate { get; set; }
        public string Passanger_MobileNumber { get; set; }
        public bool Isbooked { get; set; }
        public int TicketBookid { get; set; }
    }

    public class BusSeatSequencedetails
    {
        public int SeqNumber { get; set; }
        public int BookingId { get; set; }
        public string BookedSeats { get; set; }
        public string Passanger_Mobilenumber { get; set; }
    }


    //for pooking I/P params
    public class BookSeats
    {
        public DateTime Date { get; set; }
        public string Passanger_Mobile_number { get; set; }
        public int BusId { get; set; }
        public int SeatId { get; set; }
        public int TicketBookingId { get; set; }
    }

    public class AppsettingModles
    {
        public string Version { get; set; }
        public string AppUrl { get; set; }
        public string AppUrlMVC { get; set; }
        public string Busnumber { get; set; }

        public void CopytoStatic()
        {
            AppsettingModlesStatic.AppUrl = this.AppUrl;
            AppsettingModlesStatic.AppUrlMVC = this.AppUrlMVC;
            AppsettingModlesStatic.Version = this.Version;
            AppsettingModlesStatic.Busnumber = this.Busnumber;
        }
    }


    public static class AppsettingModlesStatic
    {
        public static string Version { get; set; }
        public static string AppUrl { get; set; }
        public static string AppUrlMVC { get; set; }
        public static string Busnumber { get; set; }
    }
    public static class InstanceCode
    {
        public static int ConductorKey { get; } = 0;

    }
    public static class CommonInformation
    {
        public static string BusNumber { get; set; } = "";
        public static string Appsettingkey { get; } = "ApplicationDetails";

        public static string AppsettingApiurlkey { get; } = "ApplicationDetails:AppUrl";

    }
}
