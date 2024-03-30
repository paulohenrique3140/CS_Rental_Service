using System.Text;
using System.Globalization;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;
using CS_Rental_Service.Entities.Registers;


namespace CS_Rental_Service
{
class Program
{
static void Main(string[] args)
{

        Car_Register carRegister = new Car_Register("Car");
        Client_Register clientRegister = new Client_Register("Client");
        Individual individualClient = new Individual();
        Company companyClient = new Company();
        Car car = new Car();
        Rental companyRental = new Company_Rental();
        Rental individualRental = new Individual_Rental();


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
                                                Console.Write("\n[1] Client Registration\n[2] Client Removal\n[3] Client search \n[4] Show Client List\n[5] Show Client Contracts\n[0] Return to main menu");
                                                Console.Write("\n\nChoose an option: ");
                                                clientMenuOption = int.Parse(Console.ReadLine());
                                                clientMenuOption = ValidateOption(clientMenuOption, 5);

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
                                                                        Console.WriteLine($"\nUser successfully added. \n{companyClient}");
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
                                                                clientRegister.RemoveClient(idRemoval);
                                                                Console.Write("\nClient removed!");
                                                                break;

                                                        case 3:
                                                                Console.WriteLine("\n### CLIENT SEARCH ###");
                                                                Console.Write("\nEnter the client ID: ");
                                                                int idSearch = int.Parse(Console.ReadLine());
                                                                Console.WriteLine(clientRegister.FindById(idSearch));
                                                                break;
                                                        case 4:
                                                                Console.WriteLine("\n### CLIENT LIST ###");
                                                                Console.WriteLine("\n" + clientRegister);
                                                                break;
                                                        case 5:
                                                                Console.WriteLine("\n### CLIENT CONTRACTS ###");
                                                                Console.Write("\nEnter the client ID: ");
                                                                int idShowContracts = int.Parse(Console.ReadLine());
                                                                Console.WriteLine("\nCONTRACT LIST");
                                                                Console.WriteLine(clientRegister.FindById(idShowContracts).GetClientContracts());
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

                                                switch (carMenuOption)
                                                {
                                                        case 1:
                                                                Console.WriteLine("\n### CAR REGISTRATION ###");
                                                                Console.Write("\nCar License Plate: ");
                                                                string licensePlate = Console.ReadLine().ToUpper();
                                                                Console.Write("\nModel: ");
                                                                string model = Console.ReadLine();
                                                                Console.Write("\nCategory [Economic / Intermediary / Special / SUV / Executive]: ");
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
                                                Console.Write("\n[1] Rent\n[2] Find Contracts\n[3] Return a Car\n[0] Return to main menu");
                                                Console.Write("\n\nChoose an option: ");
                                                rentMenuOption = int.Parse(Console.ReadLine());
                                                rentMenuOption = ValidateOption(rentMenuOption, 4);

                                                switch (rentMenuOption)
                                                {
                                                        case 1:
                                                                Console.WriteLine("\n####### RENT #######");
                                                                Console.Write("\nIt will be a car rental for a company or for an individual? [c / i]: ");
                                                                char ciRent = char.Parse(Console.ReadLine());
                                                                ciRent = ValidateChar(ciRent);

                                                                Console.Write("\nContract Number: ");
                                                                int contractNumber = int.Parse(Console.ReadLine());

                                                                Console.Write("\nCar License Plate: ");
                                                                string carLicenseRent = Console.ReadLine();
                                                                
                                                                Console.Write("\nEnter the Client ID: ");
                                                                int idRent = int.Parse(Console.ReadLine());

                                                                DateTime contractDate = DateTime.Now;

                                                                Console.Write("\nPicukp Date (dd/MM/yyyy 12:00 / 13:30 / 20:50): ");
                                                                string pickupRent = Console.ReadLine();
                                                                DateTime pickUp = DateTime.ParseExact(pickupRent + ":00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                                                                Console.Write("\nReturn Date (dd/MM/yyyy 12:00 / 13:30 / 20:50): ");
                                                                string returnRent = Console.ReadLine();
                                                                DateTime returnCar = DateTime.ParseExact(returnRent + ":00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                                                                Console.Write("\nForm of Payment (Credit, Cash, Invoice): ");
                                                                string fop = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                                                                FOP formOfPayment = Enum.Parse<FOP>(fop);

                                                                if (ciRent == 'c')
                                                                {
                                                                        ContractType typeRent = ContractType.Company;
                                                                        Console.Write("\nAgreement: ");
                                                                        string agreement = Console.ReadLine();
                                                                        Console.Write("\nAproover: ");
                                                                        string aproover = Console.ReadLine();
                                                                        Console.Write("\nRequest: ");
                                                                        int request = int.Parse(Console.ReadLine());

                                                                        companyRental = new Company_Rental(contractNumber, typeRent, carLicenseRent, idRent, contractDate, pickUp, returnCar, formOfPayment, ContractStatus.Open, carRegister, clientRegister, agreement, aproover, request);
                                                                       
                                                                        Console.WriteLine();
                                                                        Console.WriteLine("\nSumary");
                                                                        Console.WriteLine(Sumary(companyRental, clientRegister, carRegister));

                                                                        Console.Write("\nAre you in agreement and do you confirm the finalization of the contract? [y / n]? ");
                                                                        char ans = char.Parse(Console.ReadLine().ToLower());
                                                                        ans = CheckAnswer(ans);

                                                                        if (ans == 'y')
                                                                        {
                                                                                clientRegister.FindById(idRent).AddContract(companyRental, clientRegister, carRegister);
                                                                                Console.WriteLine("\nYour contract has been successfully confirmed!");
                                                                                Console.WriteLine(companyRental);
                                                                        }
                                                                        else
                                                                        {
                                                                                Console.WriteLine("\nThank you for your interest, we are looking forward to seeing you! Returning to the menu.");
                                                                        }

                                                                }
                                                                else
                                                                {
                                                                        Console.Write("\nSecurity Deposit: $");
                                                                        double secutiryDeposit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                                                        ContractType typeRent = ContractType.Individual;
                                                                       
                                                                        individualRental = new Individual_Rental(contractNumber, typeRent, carLicenseRent, idRent, contractDate, pickUp, returnCar, formOfPayment, ContractStatus.Open, carRegister, clientRegister, secutiryDeposit);
                                                                       
                                                                        Console.WriteLine();
                                                                        Console.WriteLine("\nSumary");
                                                                        Console.WriteLine(Sumary(individualRental, clientRegister, carRegister));

                                                                        Console.Write("\nAre you in agreement and do you confirm the finalization of the contract? [y / n]? ");
                                                                        char ans = char.Parse(Console.ReadLine().ToLower());
                                                                        ans = CheckAnswer(ans);

                                                                        if (ans == 'y')
                                                                        {
                                                                                clientRegister.FindById(idRent).AddContract(individualRental, clientRegister, carRegister);
                                                                                Console.WriteLine("\nYour contract has been successfully confirmed!");
                                                                                Console.WriteLine(individualRental);
                                                                        }
                                                                        else
                                                                        {
                                                                                Console.WriteLine("\nThank you for your interest, we are looking forward to seeing you! Returning to the menu.");
                                                                        }
                                                                }
                                                                break;
                                                        case 2:
                                                                Console.WriteLine("\n####### FIND A CONTRACT #######");
                                                                Console.WriteLine("Contract Number: ");
                                                                int findContract = int.Parse(Console.ReadLine());
                                                                Console.WriteLine(clientRegister.FindContract(findContract));
                                                                break;
                                                        case 3:
                                                                Console.WriteLine("\n####### RETURN A CAR #######");
                                                                Console.Write("Contract Number: ");
                                                                int returnContract = int.Parse(Console.ReadLine());
                                                                Console.WriteLine();
                                                                Console.WriteLine(clientRegister.FindContract(returnContract));
                                                                Console.WriteLine("\nAre you sure you would like to return the car and end this contract? [y/n]");
                                                                char ansRet = char.Parse(Console.ReadLine().ToLower());
                                                                ansRet = CheckAnswer(ansRet);
                                                                if (ansRet == 'y')
                                                                {
                                                                        clientRegister.ReturnCar(returnContract, carRegister);
                                                                        Console.WriteLine("The contract has been successfully terminated! Thank you and come back anytime!");
                                                                }       
                                                                else
                                                                {
                                                                        Console.WriteLine("Okay, we're always at your disposal whenever you need. Returning to the menu.");
                                                                }
                                                                
                                                                break;
                                                        default:
                                                                break;
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
public static string Sumary(Rental rental, Client_Register clientRegister, Car_Register carRegister)
{
        Car sumaryCar = carRegister.FindByLicensePlate(rental.CarLicensePlate);
        Client sumaryClient = clientRegister.FindById(rental.ClientId);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(sumaryClient.ToString());
        sb.AppendLine("Pickup date: " + rental.PickUp.ToString("dd/MM/yyyy HH:mm:ss tt"));
        sb.AppendLine("Return date: " + rental.ReturnCar.ToString("dd/MM/yyyy HH:mm:ss tt"));
        sb.AppendLine("Model: " + sumaryCar.Model);
        sb.AppendLine("Rate: $ " + sumaryCar.Rate.ToString("F2", CultureInfo.InvariantCulture));
        sb.AppendLine("Total: $ " + rental.TotalValue().ToString("F2", CultureInfo.InvariantCulture));
        return sb.ToString();
}

public static char CheckAnswer(char ans)
{
        while (ans != 'y' && ans != 'n')
        {
                Console.Write("Wrong answer, please choose again (y / n)");
                ans = char.Parse(Console.ReadLine().ToLower());
        }
        return ans;
}


}
}




