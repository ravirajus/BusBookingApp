using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interface
{
    public interface ITicketsBookingOperations
    {



        //assuming we are taken Bus KA01 
        public List<ListbusSeatdetailsLower> GetAvilableBusTicketsDetails(DateTime BookingDate, string busnumber);

        public int BookTickets(List<busSeatdetails> Busdata);

        public void UpdateBookedTickets(int seatId, int busId, string Passanger_Mobile_Number, DateTime Bookingdate, int TicketBookingId);


        public List<BusSeatSequencedetails> TicketBookingDetails(DateTime BookingDate);


    }
}
