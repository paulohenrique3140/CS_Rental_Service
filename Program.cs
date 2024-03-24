using System;
using System.Globalization;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;

namespace CS_Rental_Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Client iclient = new Individual(24, "119934069298", "email@email", "40675162823", "Paulo Henrique", 45);
            Console.WriteLine(iclient);

            Client cclient = new Company(25, "114484498489", "company@company.com", "005151515545/0001", "Industrias Calixto");
            Console.WriteLine();            
            Console.WriteLine(cclient);

            Car car = new Car("ABC1234", "Ford Ka", CarCategory.Economic, 130.00, true);
            Console.WriteLine();
            Console.WriteLine(car);

            Car car2 = new Car("BCD1234", "Ford Citrus", CarCategory.Economic, 130.00, true);
            Console.WriteLine();
            Console.WriteLine(car);

            Car car3 = new Car("EFG7878", "Huynday HB20", CarCategory.Executive, 460.00, true);
            Console.WriteLine();
            Console.WriteLine(car);

            DateTime pickup = DateTime.ParseExact("24/03/2024",  "dd/MM/yyyy",
    CultureInfo.InvariantCulture);
            DateTime returnCar = DateTime.ParseExact("27/03/2024",  "dd/MM/yyyy",
    CultureInfo.InvariantCulture);

            Rental rental = new Individual_Rental(1, car.LicensePlate, iclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open, ContractType.Individual, 1000.00);
            Console.WriteLine();
            Console.WriteLine(rental);
            Console.WriteLine("Total value: $ " + rental.TotalValue().ToString("F2", CultureInfo.InvariantCulture));

            Rental companyRental = new Company_Rental(2, car2.LicensePlate, cclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open, ContractType.Company, "Agree", "Aproover", 1234);
            Console.WriteLine();
            Console.WriteLine(companyRental);
            Console.WriteLine("Total value: $ " + companyRental.TotalValue().ToString("F2", CultureInfo.InvariantCulture));

            Rental rentalTwo = new Individual_Rental(3, car3.LicensePlate, iclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open, ContractType.Individual, 1200.00);
            Console.WriteLine();
            Console.WriteLine(rentalTwo);
            Console.WriteLine("Total value: $ " + rentalTwo.TotalValue().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(companyRental);

            Console.WriteLine();
            Console.WriteLine(iclient);
            Console.WriteLine(cclient);
        }
    }
}

