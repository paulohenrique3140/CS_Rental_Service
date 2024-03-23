using System;

namespace CS_Rental_Service.Entities
{
    class Car
    {
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public double Rate { get; set; }
        public bool Availability { get; set; }

        public Car()
        {}

        public Car(string licensePlate, string model, string category, double rate, bool availability)
        {
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