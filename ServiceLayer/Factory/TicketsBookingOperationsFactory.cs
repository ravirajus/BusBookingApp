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

    public static class TemperatureConverter
    {
      
        public static double CelsiusToFahrenheit(string temperatureCelsius)
        {
            // Convert argument to double for calculations.
            double celsius = Double.Parse(temperatureCelsius);

            // Convert Celsius to Fahrenheit.
            double fahrenheit = (celsius * 9 / 5) + 32;

            return fahrenheit;
        }

        public static double FahrenheitToCelsius(string temperatureFahrenheit)
        {
            // Convert argument to double for calculations.
            double fahrenheit = Double.Parse(temperatureFahrenheit);

            // Convert Fahrenheit to Celsius.
            double celsius = (fahrenheit - 32) * 5 / 9;

            return celsius;
        }
    }
}
