using System;
using ServiceLayer.Interface;
using DataAccessLayer;
using System.Collections.Generic;
using System.Data;

namespace ServiceLayer.Implementation
{
    public class Conductor : ITicketsBookingOperations
    {
        public BookTicketsDAL BookticketDAL = new BookTicketsDAL();
        int Rowseffected = 0;

        public int BookTickets(List<busSeatdetails> Busdata)
        {

            return Rowseffected = BookticketDAL.bookTickets(Busdata);
        }

        public List<ListbusSeatdetailsLower> GetAvilableBusTicketsDetails(DateTime BookingDate, string busnumber)
        {

            return BookticketDAL.GetBusSeatDetail(BookingDate, busnumber);
        }

        public List<BusSeatSequencedetails> TicketBookingDetails(DateTime BookingDate)
        {
            return BookticketDAL.TicketBookingDetails(BookingDate);
        }

        public void UpdateBookedTickets(int seatId, int busId, string Passanger_Mobile_Number, DateTime Bookingdate, int TicketBookingId)
        {
            throw new NotImplementedException();
        }
    }
}
