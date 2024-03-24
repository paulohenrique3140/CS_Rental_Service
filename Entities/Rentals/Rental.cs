using System;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities;
using System.Text;
using System.Diagnostics.Contracts;

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
        
        public Rental()
        {
        }
        public Rental(int contractNumber, string carLicensePlate, int clientId, DateTime contractDate, DateTime pickUp, DateTime returnCar, FOP formOfPayment, ContractStatus status, ContractType type)
        {
            ContractNumber = contractNumber;
            CarLicensePlate = carLicensePlate;
            ClientId = clientId;
            ContractDate = contractDate;
            PickUp = pickUp;
            ReturnCar = returnCar;
            FormOfPayment = formOfPayment;
            Status = status;
            Type = type;
        }

        public int CheckPeriod()
        {
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
            sb.AppendLine("Contract Date: " + ContractDate);
            sb.AppendLine("Picukp Date: " + PickUp);
            sb.AppendLine("Return Date: " + ReturnCar);
            sb.AppendLine("Form Of Payment: " + FormOfPayment);
            sb.AppendLine("Contract Status: " + Status);
            sb.AppendLine("Contract Type: " + Type);
            
            return sb.ToString();
        }

    }
}