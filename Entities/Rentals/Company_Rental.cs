using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Registers;

namespace CS_Rental_Service.Entities.Rentals
{
    class Company_Rental : Rental
    {
        public string Agreement { get; set; }
        public string Aproover { get; set; }
        public int Request { get; set; }
        
        public Company_Rental()
        {}

        public Company_Rental(int contractNumber, ContractType type, string carLicensePlate, int clientId, DateTime contractDate, DateTime pickUp, DateTime returnCar, FOP formOfPayment, ContractStatus status, Car_Register registerCar, string agreement, string aproover, int request) : base(contractNumber, type, carLicensePlate, clientId, contractDate, pickUp, returnCar, formOfPayment, status, registerCar)
        {
            Agreement = agreement;
            Aproover = aproover;
            Request = request;
        }

        public int CompanyDiscount()
        {
            int discount = 10;

            if(RegisterCar.FindByLicensePlate(CarLicensePlate).Category == CarCategory.Economic || RegisterCar.FindByLicensePlate(CarLicensePlate).Category == CarCategory.Intermediary)
            {
                discount = 5;
            }

            return discount;
        }
        
        public override double TotalValue()
        {            
            double total = RegisterCar.FindByLicensePlate(CarLicensePlate).Rate * CheckPeriod();
            return total - (total * CompanyDiscount() / 100);
        }

        public override string ToString()
        {
            return base.ToString()
                 + "\nAgreement: " + Agreement
                 + "\nAproover: " + Aproover
                 + "\nRequest: " + Request;
        }
    }
}