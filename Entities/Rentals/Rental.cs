using System;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities;
using CS_Rental_Service.Entities.Registers;
using System.Text;

namespace CS_Rental_Service.Entities.Rentals
{
    abstract class Rental
    {

        public int ContractNumber { get; set; }
        public ContractType Type { get; set; }
        public string CarLicensePlate { get; set; }
        public int ClientId { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime ReturnCar { get; set; }
        public FOP FormOfPayment { get; set; }
        public ContractStatus Status { get; set; }
        public Car_Register RegisterCar { get; set; }
        public Client_Register ClientRegister { get; set; }

        public Rental()
        {
        }
        public Rental(int contractNumber, ContractType type, string carLicensePlate, int clientId, DateTime contractDate, DateTime pickUp, DateTime returnCar, FOP formOfPayment, ContractStatus status, Car_Register registerCar, Client_Register clientRegister)
        {
            ClientRegister = clientRegister;

            if (clientRegister.IsThereAContract(contractNumber))
            {
                throw new DomainException("There is already a contract with this number. Please try with another number.");
            }
            ContractNumber = contractNumber;

            RegisterCar = registerCar;

            if (registerCar.FindByLicensePlate(carLicensePlate) == null)
            {
                throw new DomainException("There is no car with this License Plate. Try again.");
            }
            CarLicensePlate = carLicensePlate;
            
            if (clientRegister.findById(clientId, type) == null)
            {
                throw new DomainException("There is no client with this ID. Try again.");
            }
            ClientId = clientId;

            ContractDate = contractDate;

            if (pickUp < DateTime.Now || returnCar < DateTime.Now)
            {
                throw new DomainException("Reservation dates for update must be future dates");
            }

            if (returnCar < pickUp)
            {
                throw new DomainException("Return Date date must be after or equal Pickup Date");
            }
            PickUp = pickUp;
            ReturnCar = returnCar;
            Type = type;
            FormOfPayment = formOfPayment;

            if (type == ContractType.Individual && formOfPayment == FOP.Invoice)
            {
                throw new DomainException("The payment method is not accepted for this type of customer. Please try cash or credit card.");
            }
            Status = status;            
        }

        public int CheckPeriod()
        {
            if (PickUp == ReturnCar) 
            {
                return 1;
            }
            
            TimeSpan difference = ReturnCar.Subtract(PickUp);
            return (int)difference.TotalDays;
        }

        public abstract double TotalValue();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nContract Number: " + ContractNumber);
            sb.AppendLine("Car: " + CarLicensePlate);
            sb.AppendLine("Client ID: " + ClientId);
            sb.AppendLine("Contract Date: " + ContractDate.ToString("dd/MM/yyyy hh:mm:ss tt"));
            sb.AppendLine("Picukp Date: " + PickUp.ToString("dd/MM/yyyy hh:mm:ss tt"));
            sb.AppendLine("Return Date: " + ReturnCar.ToString("dd/MM/yyyy hh:mm:ss tt"));
            sb.AppendLine("Form Of Payment: " + FormOfPayment);
            sb.AppendLine("Contract Status: " + Status);
            sb.AppendLine("Contract Type: " + Type);

            return sb.ToString();
        }

    }
}