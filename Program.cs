using System;
using System.Collections.Generic;
using System.Globalization;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;
using CS_Rental_Service.Entities.Registers;
using System.Net.Mail;

namespace CS_Rental_Service
{
  class Program
  {
    private static void Main(string[] args)
    {
      Car_Register carRegister = new Car_Register("Car");
      Client_Register clientRegister = new Client_Register("Client");
      Individual individualClient = new Individual();
      Company companyClient = new Company();
      Car car = new Car();
      Rental companyRental = new Company_Rental();
      Rental individualRental = new Individual_Rental();
      DateTime now = DateTime.Now;

     int mainMenuOption = 1;

     do
     {
        try
        {
                Console.WriteLine("\n####### WELCOME TO CAR RENTAL SERVICE #######");
                Console.WriteLine("\nMenu:");
                Console.Write("\n[1] Client Register\n[2] Car Register\n[3] Rent a Car\n[0] Exit");
                Console.Write("\n\nChoose an option: ");
                mainMenuOption = int.Parse(Console.ReadLine());
                mainMenuOption = ValidateOption(mainMenuOption, 3);

                switch (mainMenuOption)
                {
                        case 1:
                                int clientMenuOption = 1;
                                do
                                {
                                        Console.WriteLine("\n####### CLIENT SESSION #######");
                                        Console.WriteLine("\nMenu:");
                                        Console.Write("\n[1] Client Registration\n[2] Client Removal\n[3] Client search \n[4] Show Client List\n[0] Return to main menu");
                                        Console.Write("\n\nChoose an option: ");
                                        clientMenuOption = int.Parse(Console.ReadLine());
                                        clientMenuOption = ValidateOption(clientMenuOption, 4);

                                        switch (clientMenuOption)
                                        {
                                                case 1:
                                                        Console.WriteLine("\n### CLIENT REGISTRATION ###");
                                                        Console.Write("\nDo you'll registrate a company or a individual client? [c / i]: ");
                                                        char ci = char.Parse(Console.ReadLine().ToLower());
                                                        ci = ValidateChar(ci);
                                                        Console.Write("\nID: ");
                                                        int id = int.Parse(Console.ReadLine());
                                                        Console.Write("\nName: ");
                                                        string name = Console.ReadLine();
                                                        Console.Write("\nPhonne: ");
                                                        string phonne = Console.ReadLine();
                                                        Console.Write("\nEmail: ");
                                                        string email = Console.ReadLine();
                                                        if (ci == 'c')
                                                        {
                                                                Console.Write("\nCNPJ: ");
                                                                string cnpj = Console.ReadLine();
                                                                companyClient = new Company(id, name, phonne, email, clientRegister, cnpj);
                                                                clientRegister.AddClient(companyClient);
                                                                Console.WriteLine($"User successfully added. \n{companyClient}");
                                                        }
                                                        else
                                                        {
                                                                Console.Write("\nCPF: ");
                                                                string cpf = Console.ReadLine();
                                                                individualClient = new Individual(id, name, phonne, email, clientRegister, cpf);
                                                                clientRegister.AddClient(individualClient);
                                                                Console.WriteLine($"User successfully added. \n{individualClient}");
                                                        }
                                                        break;

                                                case 2:
                                                        Console.WriteLine("\n### CLIENT REMOVAL ###");
                                                        Console.Write("\nEnter the client ID to remove: ");
                                                        int idRemoval = int.Parse(Console.ReadLine());
                                                        Console.Write("\nClient i or client c? [i / c]: ");
                                                        char ciRemoval = char.Parse(Console.ReadLine());
                                                        ciRemoval = ValidateChar(ciRemoval);
                                                        if (ciRemoval == 'c')
                                                        {
                                                                clientRegister.RemoveClient(idRemoval, ContractType.Company);
                                                        }
                                                        else
                                                        {
                                                                clientRegister.RemoveClient(idRemoval, ContractType.Individual);
                                                        }
                                                        Console.Write("\nCar removed!");
                                                        break;

                                                case 3:
                                                        Console.WriteLine("\n### CLIENT SEARCH ###");
                                                        Console.Write("\nEnter the client ID: ");
                                                        int idSearch = int.Parse(Console.ReadLine());
                                                        Console.Write("\nClient i or client c? [i / c]");
                                                        char ciSearch = char.Parse(Console.ReadLine());
                                                        ciSearch = ValidateChar(ciSearch);
                                                        if (ciSearch == 'c')
                                                        {
                                                                Console.WriteLine(clientRegister.findById(idSearch, ContractType.Company));
                                                        }
                                                        else
                                                        {
                                                                Console.WriteLine(clientRegister.findById(idSearch, ContractType.Individual));
                                                        }
                                                        break;
                                                case 4:
                                                        Console.WriteLine("\n### CLIENT LIST ###");
                                                        Console.WriteLine("\n" + clientRegister);
                                                        break;
                                                default:
                                                        break;
                                        }

                                } while (clientMenuOption != 0);
                                break;
                        case 2:
                                int carMenuOption = 1;
                                do
                                {
                                    Console.WriteLine("\n####### CAR SESSION #######");
                                    Console.WriteLine("\nMenu:");
                                    Console.Write("\n[1] Car Registration\n[2] Car Removal\n[3] Car search by License Plate\n[4] Car Seach by Model\n[5] Show Car List\n[0] Return to main menu");
                                    Console.Write("\n\nChoose an option: ");
                                    carMenuOption = int.Parse(Console.ReadLine());
                                    carMenuOption = ValidateOption(carMenuOption, 5);

                                    switch(carMenuOption)
                                    {
                                        case 1:
                                                Console.WriteLine("\n### CAR REGISTRATION ###");
                                                Console.Write("\nCar License Plate: ");
                                                string licensePlate = Console.ReadLine().ToUpper();
                                                Console.Write("\nModel: ");
                                                string model = Console.ReadLine();
                                                Console.Write("\nCategory [Economic / Intermediary / Special / SUV / Excutive]: ");
                                                string cat = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                                                CarCategory category = Enum.Parse<CarCategory>(cat);
                                                Console.Write("\nRate: ");
                                                double rate = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                                car = new Car(licensePlate, model, category, rate, true);
                                                carRegister.AddCar(car);
                                                Console.WriteLine($"Car successfully added. \n{car}");
                                                break;
                                        case 2:
                                                Console.WriteLine("\n### CAR REMOVAL ###");
                                                Console.Write("\nEnter the License Plate to remove: ");
                                                string licenseToRemove = Console.ReadLine();
                                                carRegister.RemoveCar(licenseToRemove);
                                                Console.WriteLine("\nCar removed!");
                                                break;
                                        case 3:
                                                Console.WriteLine("\n### CAR SEARCH BY LICENCE PLATE ###");
                                                Console.Write("\nEnter the License Plate to find a car: ");
                                                string licensePlateToSearch = Console.ReadLine();
                                                Console.WriteLine(carRegister.FindByLicensePlate(licensePlateToSearch));
                                                break;
                                        case 4:
                                                Console.WriteLine("\n### CAR SEARCH BY MODEL ###");
                                                Console.Write("\nEnter the Model to find a car: ");
                                                string modelSearch = Console.ReadLine();
                                                Console.WriteLine(carRegister.FindByModel(modelSearch));
                                                break;
                                        case 5:
                                                Console.WriteLine("\n### CAR LIST ###");
                                                Console.Write("\n" + carRegister);
                                                break;
                                        default:
                                                break;
                                    }

                                } while (carMenuOption != 0);
                                break;
                        case 3:
                                int rentMenuOption = 1;
                                do
                                {
                                        Console.WriteLine("\n####### RENT A CAR #######");
                                        Console.WriteLine("\nMenu:");
                                        Console.Write("\n[1] Quotation\n[2] Rent\n[3] Find Contracts\n[4] Return a Car\n[0] Return to main menu");
                                        Console.Write("\n\nChoose an option: ");
                                        rentMenuOption = int.Parse(Console.ReadLine());
                                        rentMenuOption = ValidateOption(rentMenuOption, 4);

                                        switch (rentMenuOption)
                                        {
                                               
                                        }

                                } while (rentMenuOption != 0);
                                break;
                }
        }
        catch (DomainException e)
        {
                Console.WriteLine("\nError! " + e.Message);
        }
        catch (FormatException)
        {
                Console.WriteLine("\nError! You entered the incorrect data type for the requested field. Please try again.");
        }
        catch (SystemException e)
        {
                Console.WriteLine("\nError! " + e.Message);
        }

      } while (mainMenuOption != 0);




                        /*
                        // instances
                       

                        // Individual client criation test
                        Client iclient = new Individual(24, "119934069298", "email@email", "40675162823", "Paulo Henrique", 0);
                        clientRegister.AddClient(iclient);
                        Console.WriteLine(iclient);

                        // Company client criation test
                        Client cclient = new Company(25, "114484498489", "company@company.com", "005151515545/0001", "Industrias Calixto");
                        Console.WriteLine();
                        Console.WriteLine(cclient);
                        clientRegister.AddClient(cclient);

                        // Find client by ID
                        Console.WriteLine();
                        Console.WriteLine(clientRegister.findById(24, ContractType.Individual));

                        // Find client by ID
                        Console.WriteLine();
                        Console.WriteLine(clientRegister.findById(25, ContractType.Company));

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

                        // Tests with DateTime (ParseExact)
                        DateTime pickup = DateTime.ParseExact("28/03/2024", "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
                        DateTime returnCar = DateTime.ParseExact("30/03/2024", "dd/MM/yyyy",
                CultureInfo.InvariantCulture);

                        DateTime pickup2 = DateTime.ParseExact("05/04/2024", "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                        DateTime returnCar2 = DateTime.ParseExact("06/04/2024", "dd/MM/yyyy",
                CultureInfo.InvariantCulture);

                        DateTime pickup3 = DateTime.ParseExact("10/05/2024", "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                        DateTime returnCar3 = DateTime.ParseExact("15/05/2024", "dd/MM/yyyy",
                CultureInfo.InvariantCulture);

                        // Tests with Rental create                        
                        Rental rental = new Individual_Rental(1, ContractType.Individual, car.LicensePlate, iclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open, carRegister, 1000.00);
                        individual.AddContract(rental, clientRegister, carRegister);
                        Console.WriteLine();
                        Console.WriteLine(rental);
                        
                        Rental companyRental = new Company_Rental(2, ContractType.Company, car2.LicensePlate, cclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open, carRegister, "Agree", "Aproover", 1234);
                        companyClient.AddContract(companyRental, clientRegister, carRegister);
                        Console.WriteLine();
                        Console.WriteLine(companyRental);
                        
                        Rental rentalTwo = new Individual_Rental(3, ContractType.Individual, car3.LicensePlate, iclient.Id, DateTime.Now, pickup, returnCar, FOP.CreditCard, ContractStatus.Open, carRegister, 1200.00);
                        individual.AddContract(rentalTwo, clientRegister, carRegister);
                        Console.WriteLine();
                        Console.WriteLine(rentalTwo);
                        
                        // Printing clients
                        Console.WriteLine();
                        Console.WriteLine(iclient);
                        Console.WriteLine(cclient);

                        // Printing cars
                        Console.WriteLine();
                        Console.WriteLine(car);
                        Console.WriteLine(car2);
                        Console.WriteLine(car3);

                        // Test findContract
                        Console.WriteLine();
                        Console.WriteLine(clientRegister.findContract(1, ContractType.Individual));
                        Console.WriteLine(clientRegister.findContract(2, ContractType.Company));
                        Console.WriteLine(clientRegister.findContract(3, ContractType.Individual));

                        // Returning cars tests
                        Console.WriteLine("Returning tests");
                        clientRegister.ReturnCar(3, ContractType.Individual, carRegister);
                        Console.WriteLine(rentalTwo);
                        Console.WriteLine(car3);
                        Console.WriteLine(iclient + "\nContract List: \n" + iclient.GetClientContracts());

                        // show car list
                        Console.WriteLine();
                        Console.WriteLine("Car list");
                        Console.WriteLine(carRegister);

                        // show client list
                        Console.WriteLine();
                        Console.WriteLine("Client list");
                        Console.WriteLine(clientRegister);

                        // find by model
                        Console.WriteLine();
                        Console.WriteLine("Find by model");
                        Console.WriteLine(carRegister.FindByModel("Ford Ka"));

                        // remove client and show client list
                        Console.WriteLine();
                        Console.WriteLine("Remove client");
                        clientRegister.RemoveClient(24, ContractType.Individual);
                        Console.WriteLine("Client list");
                        Console.WriteLine(clientRegister);

                        // remove car and show car list
                        Console.WriteLine();
                        Console.WriteLine("Remove car");
                        carRegister.RemoveCar("EFG7878");
                        Console.WriteLine("Car list");
                        Console.WriteLine(carRegister);  
                        */
                }

                public static int ValidateOption(int option, int limit)
                {
                        while (option < 0 || option > limit)
                        {
                                Console.Write("\nInvalid option. Try again: ");
                                option = int.Parse(Console.ReadLine());
                        }
                        return option;
                }

                public static char ValidateChar(char ci)
                {
                        while (ci != 'c' && ci != 'i')
                        {
                                Console.Write("\nInvalid option. Try again: ");
                                ci = char.Parse(Console.ReadLine());
                        }
                        return ci;
                }
        }
}

