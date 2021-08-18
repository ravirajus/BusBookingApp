using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ServiceLayer.Factory;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;

namespace BusBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketBookingController : ControllerBase
    {

        public TicketBookingController(IOptions<AppsettingModles> configP)
        {

        }

        [HttpGet]
        [Route("GetAvilableBusTickets")]
        public string GetAvilableBusTickets(string datetime)
        {
            List<ListbusSeatdetailsLower> results = new List<ListbusSeatdetailsLower>();
            ITicketsBookingOperations Conductorinstance = TicketsBookingOperationsFactory.TicketsBookingOperationsInstances(InstanceCode.ConductorKey); //new Conductor();
            DateTime TicketDate;
            DateTime.TryParse(datetime, out TicketDate);
            results = Conductorinstance.GetAvilableBusTicketsDetails(TicketDate, AppsettingModlesStatic.Busnumber);
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