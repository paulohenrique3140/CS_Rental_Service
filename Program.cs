using System;
using System.Globalization;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;
using CS_Rental_Service.Entities.Registers;

namespace CS_Rental_Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Car_Register carRegister = new Car_Register("Car");
            Client_Register clientRegister = new Client_Register("Client");
            Individual individual = new Individual();
            Company companyClient = new Company(); // fix

                    

            // Individual client criation test
            Client iclient = new Individual(24, "119934069298", "email@email", "40675162823", "Paulo Henrique", 0);
            clientRegister.AddClient(iclient);
            Console.WriteLine(iclient);

            // Company client criation test
            Client cclient = new Company(25, "114484498489", "company@company.com", "005151515545/0001", "Industrias Calixto");
            Console.WriteLine();            
            Console.WriteLine(cclient);
            clientRegister.AddClient(cclient);

            // Car 1 creation test
            Car car = new Car("ABC1234", "Ford Ka", CarCategory.Economic, 130.00, true);
            Console.WriteLine();
            Console.WriteLine(car);
            carRegister.AddCar(car);

            // Car 2 creation test
            Car car2 = new Car("BCD1234", "Ford Citrus", CarCategory.Economic, 130.00, true);
            Console.WriteLine();
            Console.WriteLine(car2);
            carRegister.AddCar(car2);

            // // Car 3 creation test
            Car car3 = new Car("EFG7878", "Huynday HB20", CarCategory.Executive, 460.00, true);
            Console.WriteLine();
            Console.WriteLine(car3);
            carRegister.AddCar(car3);

            DateTime pickup = DateTime.ParseExact("28/03/2024",  "dd/MM/yyyy",
    CultureInfo.InvariantCulture);
            DateTime returnCar = DateTime.ParseExact("30/03/2024",  "dd/MM/yyyy",
    CultureInfo.InvariantCulture);

    DateTime pickup2 = DateTime.ParseExact("05/04/2024",  "dd/MM/yyyy",
    CultureInfo.InvariantCulture);
            DateTime returnCar2 = DateTime.ParseExact("06/04/2024",  "dd/MM/yyyy",
    CultureInfo.InvariantCulture);

    DateTime pickup3 = DateTime.ParseExact("10/05/2024",  "dd/MM/yyyy",
    CultureInfo.InvariantCulture);
            DateTime returnCar3 = DateTime.ParseExact("15/05/2024",  "dd/MM/yyyy",
    CultureInfo.InvariantCulture);

            Rental rental = new Individual_Rental(1, ContractType.Individual,car.LicensePlate, iclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open,  carRegister, 1000.00);
            individual.AddContract(rental, clientRegister, carRegister);
            Console.WriteLine();
            Console.WriteLine(rental);
            Console.WriteLine("Total value: $ " + rental.TotalValue().ToString("F2", CultureInfo.InvariantCulture)); // fix
            

            Rental companyRental = new Company_Rental(2, ContractType.Company, car2.LicensePlate, cclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open, carRegister, "Agree", "Aproover", 1234);
            companyClient.AddContract(companyRental, clientRegister, carRegister);
            Console.WriteLine();
            Console.WriteLine(companyRental);
            Console.WriteLine("Total value: $ " + companyRental.TotalValue().ToString("F2", CultureInfo.InvariantCulture));

            Rental rentalTwo = new Individual_Rental(3, ContractType.Individual, car3.LicensePlate, iclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open, carRegister, 1200.00);
            individual.AddContract(rentalTwo, clientRegister, carRegister);
            Console.WriteLine();
            Console.WriteLine(rentalTwo);
            Console.WriteLine("Total value: $ " + rentalTwo.TotalValue().ToString("F2", CultureInfo.InvariantCulture));
            

            Console.WriteLine();
            Console.WriteLine(iclient);
            Console.WriteLine(cclient);

            Console.WriteLine();
            Console.WriteLine(car);
            Console.WriteLine(car2);
            Console.WriteLine(car3);
        }
    }
}

