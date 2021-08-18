using System;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLayer
{
    public class BookTicketsRepo
    {
        public DataSet Ds;
        public SqlConnection sqlcon;
        public SqlDataReader myreader;
        public int Rowseffected = 0;
        public void ConOpen()
        {
            sqlcon.Open();
        }
        public void ConClose()
        {
            sqlcon.Close();
        }

        public DataTable GetticketsBookDetails(DateTime datetime)
        {
            using (sqlcon = new SqlConnection(
               ReposModel.ConectionString))
            {
                SqlCommand command = new SqlCommand(Sp_Get_Booking_Detail.Sp_Name, sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Sp_Get_Booking_Detail.Sp_Date_Parameter, datetime));
                ConOpen();
                myreader = command.ExecuteReader();
                DataTable BussdetailsTbl = new DataTable();
                BussdetailsTbl.Load(myreader);
                ConClose();
                return BussdetailsTbl;
            }
        }

        public DataTable GetBusSeatDetail(DateTime datetime, string BusNumber)
        {
            using (sqlcon = new SqlConnection(
             ReposModel.ConectionString))
            {
                SqlCommand command = new SqlCommand(Sp_GetBusSeatDetail.Sp_Name, sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Sp_GetBusSeatDetail.Sp_Date_Parameter, datetime));
                command.Parameters.Add(new SqlParameter(Sp_GetBusSeatDetail.Sp_Busnumber_Parameter, BusNumber));
                ConOpen();
                myreader = command.ExecuteReader();
                DataTable BussdetailsTbl = new DataTable();
                BussdetailsTbl.Load(myreader);
                ConClose();
                return BussdetailsTbl;
            }
        }


        public int Booktickets(DataTable BookTicketdata)
        {
            using (sqlcon = new SqlConnection(
             ReposModel.ConectionString))
            {
                SqlCommand command = new SqlCommand(Sp_Ticket_Booking_Add_Or_Update.Sp_Name, sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Sp_Ticket_Booking_Add_Or_Update.Sp_Date_Parameter, BookTicketdata));
                ConOpen();
                Rowseffected = command.ExecuteNonQuery();
                ConClose();
                return Rowseffected;
            }
        }

        ~BookTicketsRepo()
        {

        }
    }

}
