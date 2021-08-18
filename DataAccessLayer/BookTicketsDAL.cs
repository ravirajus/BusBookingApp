using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccessLayer
{
    public class BookTicketsDAL
    {
        DataTable Ticketdatatable = new DataTable();
        public BookTicketsRepo Repo = new BookTicketsRepo();

        public List<BusSeatSequencedetails> TicketBookingDetails(DateTime Dt)
        {
            List<BusSeatSequencedetails> Finaldata = new List<BusSeatSequencedetails>();
            Ticketdatatable = Repo.GetticketsBookDetails(Dt);
            foreach (DataRow row in Ticketdatatable.Rows)
            {
                BusSeatSequencedetails b = new BusSeatSequencedetails
                {
                    BookingId = row["BookingId"] == DBNull.Value ? 0 : Convert.ToInt32(row["BookingId"]),
                    SeqNumber = row["SeqNumber"] == DBNull.Value ? 0 : Convert.ToInt32(row["SeqNumber"]),
                    BookedSeats = row["BookedSeats"] == DBNull.Value ? "" : Convert.ToString(row["BookedSeats"]),
                    Passanger_Mobilenumber = row["Passanger_Mobilenumber"] == DBNull.Value ? "" : Convert.ToString(row["Passanger_Mobilenumber"])

                };
                Finaldata.Add(b);
            }
            return Finaldata;

        }

        public List<ListbusSeatdetailsLower> GetBusSeatDetail(DateTime Dt, string Busnumber)
        {
            List<ListbusSeatdetailsLower> Finaldata = new List<ListbusSeatdetailsLower>();
            ListbusSeatdetailsLower Busseats = new ListbusSeatdetailsLower();
            Ticketdatatable = Repo.GetBusSeatDetail(Dt, Busnumber);
            int i = 1;
            foreach (DataRow row in Ticketdatatable.Rows)
            {
                busSeatdetails b = new busSeatdetails
                {
                    BusId = row["BusId"] == DBNull.Value ? 0 : Convert.ToInt32(row["BusId"]),
                    SeatId = row["SeatId"] == DBNull.Value ? 0 : Convert.ToInt32(row["SeatId"]),
                    SeatNumber = row["SeatNumber"] == DBNull.Value ? 0 : Convert.ToInt32(row["SeatNumber"]),
                    SeatRowNumber = row["SeatRowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(row["SeatRowNumber"]),
                    BookingDate = row["BookingDate"] == DBNull.Value ? "" : Convert.ToDateTime(row["BookingDate"]).ToString("MM/dd/yyyy"),
                    SeatType = row["SeatType"] == DBNull.Value ? "" : Convert.ToString(row["SeatType"]),
                    Passanger_MobileNumber = row["Passanger_MobileNumber"] == DBNull.Value ? "" : Convert.ToString(row["Passanger_MobileNumber"]),
                    Isbooked = row["Isbooked"] == DBNull.Value ? false : Convert.ToBoolean(row["Isbooked"]),
                    TicketBookid = row["TicketBookid"] == DBNull.Value ? 0 : Convert.ToInt32(row["TicketBookid"])

                };

                Busseats.S.Add(b);

            }
            var resut = Busseats.S.GroupBy(x => new { x.SeatRowNumber, x.SeatType }).ToLookup(customObject => customObject); ;

            foreach (var group in resut)
            {
                Console.WriteLine("Age Group: {0}", group.Key);  //Each group has a key 

                var t = group.SelectMany(m => m.ToList()).ToList();
                ListbusSeatdetailsLower l1 = new ListbusSeatdetailsLower
                {
                    S = t
                };
                Finaldata.Add(l1);

            }
            return Finaldata;
        }

        public int bookTickets(List<busSeatdetails> Bookticketdataparam)
        {

            DataTable BookTicketdata = new DataTable();
            BookTicketdata.Columns.Add("BusId", typeof(int));
            BookTicketdata.Columns.Add("SeatId", typeof(int));
            BookTicketdata.Columns.Add("Passanger_Mobilenumber", typeof(string));
            BookTicketdata.Columns.Add("Date", typeof(DateTime));
            BookTicketdata.Columns.Add("TicketBookId", typeof(int));

            foreach (var item in Bookticketdataparam)
            {
                DataRow row = BookTicketdata.NewRow();
                row["BusId"] = item.BusId;
                row["SeatId"] = item.SeatId;
                row["Passanger_Mobilenumber"] = item.Passanger_MobileNumber;
                row["Date"] = Convert.ToDateTime(item.BookingDate);
                row["TicketBookId"] = item.TicketBookid;
                BookTicketdata.Rows.Add(row);
            }

            return Repo.Booktickets(BookTicketdata);





        }
    }
}
