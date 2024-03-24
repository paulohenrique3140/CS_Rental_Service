using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_Rental_Service.Entities.Enums;

namespace CS_Rental_Service.Entities.Rentals
{
    class Company_Rental : Rental
    {
        public string Agreement { get; set; }
        public string Aproover { get; set; }
        public int Request { get; set; }
        
        public Company_Rental()
        {}

        public Company_Rental(int contractNumber, string carLicensePlate, int clientId, DateTime contractDate, DateTime pickUp, DateTime returnCar, FOP formOfPayment, ContractStatus status, ContractType type, string agreement, string aproover, int request) : base(contractNumber, carLicensePlate, clientId, contractDate, pickUp, returnCar, formOfPayment, status, type)
        {
            Agreement = agreement;
            Aproover = aproover;
            Request = request;
        }

        
        public override double TotalValue()
        {
            
            
            throw new NotImplementedException();
        }

        
    }
}