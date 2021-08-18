using System;
using System.Collections.Generic;
using System.Text;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;
using DataAccessLayer;

namespace ServiceLayer.Factory
{
    public static class TicketsBookingOperationsFactory
    {
        static Dictionary<int, ITicketsBookingOperations> TicketsBookingOperationsDictionary = new Dictionary<int, ITicketsBookingOperations>();

        static TicketsBookingOperationsFactory()
        {
            TicketsBookingOperationsDictionary.Add(InstanceCode.ConductorKey, new Conductor());

        }

        public static ITicketsBookingOperations TicketsBookingOperationsInstances(int InstanceCode)
        {
            ITicketsBookingOperations OutObject;
            TicketsBookingOperationsDictionary.TryGetValue(InstanceCode, out OutObject);
            return OutObject;

        }

    }
}
