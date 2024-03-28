using System;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;

namespace CS_Rental_Service.Entities
{
    internal class Car
    {
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public CarCategory Category { get; set; }
        public double Rate { get; set; }
        public bool Availability { get; set; }

        public Car()
        {}

        public Car(string licensePlate, string model, CarCategory category, double rate, bool availability)
        {
            if (licensePlate.Length != 7)
            {
                throw new DomainException("The vehicle license plate field must have 7 characters. Please try again");
            }
            LicensePlate = licensePlate;
            Model = model;
            Category = category;
            Rate = rate;
            Availability = availability;
        }

        public override string ToString()
        {
            string avail = "Available";
            if (!Availability){
                avail = "Unavailable";
            } 
            return "\nLicense Plate: " + LicensePlate
                 + " | Model: " + Model
                 + " | Category: " + Category
                 + " | Rate: $ " + Rate
                 + " | " + avail;
        }
    }
}