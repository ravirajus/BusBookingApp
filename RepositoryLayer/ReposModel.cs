using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public static class ReposModel
    {
        public static string DataSourceName { get; } = @"DESKTOP-G432O86\MSSQLSERVER2021";
        public static string DatabaseName { get; } = "BusTicketbooking";
        public static string ConectionString { get; } = @"data source=" + DataSourceName + "; Database=" + DatabaseName + "; integrated security = true";
        ////"Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";

    }

    public static class Sp_Get_Booking_Detail
    {
        public static string Sp_Name { get; } = "Get_Booking_Detail";
        public static string Sp_Date_Parameter { get; } = "@Date";

    }
    public static class Sp_GetBusSeatDetail
    {
        public static string Sp_Name { get; } = "GetBusSeatDetail";
        public static string Sp_Date_Parameter { get; } = "@Date";
        public static string Sp_Busnumber_Parameter { get; } = "@Busnumber";

    }
    public static class Sp_Ticket_Booking_Add_Or_Update
    {
        public static string Sp_Name { get; } = "Sp_Ticket_Booking_Add_Or_Update";
        public static string Sp_Date_Parameter { get; } = "@BookTicketdata";

    }

}
