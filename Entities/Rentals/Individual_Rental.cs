using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_Rental_Service.Entities.Enums;

namespace CS_Rental_Service.Entities.Rentals
{
     class Individual_Rental : Rental
    {
        
        public int FidelityPoints { get; set; }
        
        public Individual_Rental()
        {}

        public Individual_Rental(int contractNumber, string carLicensePlate, int clientId, DateTime contractDate, DateTime pickUp, DateTime returnCar, FOP formOfPayment, ContractStatus status, ContractType type, int fidelityPoints) : base(contractNumber, carLicensePlate, clientId, contractDate, pickUp, returnCar, formOfPayment, status, type)
        {
            FidelityPoints = fidelityPoints;
        }

        public override double TotalValue()
        {
            throw new NotImplementedException();
        }
    }
}