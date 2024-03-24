using System;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities;

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

        public abstract double TotalValue();
        
    }
}