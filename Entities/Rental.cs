using System;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities;

namespace CS_Rental_Service.Entities
{
    internal class Rental
    {
        public int ContractNumber { get; set; }
        public string CarLicensePlate { get; set; }
        public int ClientId { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime Return { get; set; }
        public FOP FormOfPayment { get; set; }
        public ContractStatus Status { get; set; }
        public ContractType Type { get; set; }
    }


}