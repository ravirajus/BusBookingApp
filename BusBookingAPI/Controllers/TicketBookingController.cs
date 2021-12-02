using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ServiceLayer.Factory;
using ServiceLayer.Interface;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BusBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketBookingController : ControllerBase
    {
        private static string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        public TicketBookingController(IOptions<AppsettingModles> configP)
        {
        }

        [HttpPost]
        public string GetTockens(string Username, string Password)
        {
            String Tocken = "";
            if (Username == "ISValidUser")
            {
                //  Tocken = TokenManager.GenerateToken(UserName)
            }
            return Tocken;


        }

        [HttpGet]
        [Route("GetAvilableBusTickets")]
        public string GetAvilableBusTickets(string datetime)
        {
            /////Collection
            //int[] A = new int[10];
            //A[0] = 31;
            //ArrayList AL = new ArrayList();
            //AL.Add(21);

            //Hashtable ht = new Hashtable();
            //ht.Add(2, 21);
            //SortedList SL = new SortedList();
            //SL.Add(2, 21);

            //Stack St = new Stack();
            //St.Push(1);
            //St.Push(2);
            //int PopVariable = (int)St.Pop();
            //Queue u = new Queue();
            //u.Enqueue(21);
            //u.Enqueue(23);
            //int Qobj = (int)u.Dequeue();

            ////Colledctions
            ////ArrayList<int> ALg = new ArrayList<int>();
            ////AL.Add(21);

            ////Hashtable<int, int> htg = new Hashtable<int, int>();
            ////ht.Add(2, 21);
            ////SortedList<int> SL = new SortedList<int>();
            ////SL.Add(2, 21);

            //Stack<int> Stg = new Stack<int>();
            //St.Push(1);
            //St.Push(2);
            //int PopVariableg = (int)St.Pop();

            //Queue<int> ug = new Queue<int>();
            //u.Enqueue(21);
            //u.Enqueue(23);
            //int Qobjg = (int)u.Dequeue();

            ////List is always Generic
            //Dictionary<string, int> Dc = new Dictionary<string, int>();
            //Dc.Add("A", 21);
            //Dc.Add("A", 21);



            List<ListbusSeatdetailsLower> results = new List<ListbusSeatdetailsLower>();
            ITicketsBookingOperations Conductorinstance = TicketsBookingOperationsFactory.TicketsBookingOperationsInstances(InstanceCode.ConductorKey); //new Conductor();
            DateTime TicketDate;
            DateTime.TryParse(datetime, out TicketDate);
            results = Conductorinstance.GetAvilableBusTicketsDetails(TicketDate, AppsettingModlesStatic.Busnumber);

            IEnumerable<ListbusSeatdetailsLower> IES = results;
            IEnumerator<ListbusSeatdetailsLower> Tor = IES.GetEnumerator();


            foreach (var Obj in IES)
            {
                
            }
            while (Tor.MoveNext())
            {
                Console.WriteLine("te=" + Tor.Current.S[0].BookingDate);
            }

            


            return JsonConvert.SerializeObject(results);
        }

        [HttpGet]
        [Route("GetAvilableBusBookedTicketsDetails")]
        public List<BusSeatSequencedetails> GetAvilableBusBookedTicketsDetails(string datetime)
        {
            ITicketsBookingOperations Conductorinstance = TicketsBookingOperationsFactory.TicketsBookingOperationsInstances(InstanceCode.ConductorKey);
            DateTime TicketDate;
            DateTime.TryParse(datetime, out TicketDate);
            return Conductorinstance.TicketBookingDetails(TicketDate);

        }
        [HttpPut]
        [Route("BookBusTickets")]
        public OkResult BookBusTickets(List<busSeatdetails> SeatBooked)
        {
            OkResult OK = new OkResult();
            int rowseffected = 0;
            ITicketsBookingOperations Conductorinstance = TicketsBookingOperationsFactory.TicketsBookingOperationsInstances(InstanceCode.ConductorKey);
            rowseffected = Conductorinstance.BookTickets(SeatBooked);
            return OK;

        }
    }
}