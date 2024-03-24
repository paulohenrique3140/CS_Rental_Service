using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Registers;

namespace CS_Rental_Service.Entities.Rentals
{
     class Individual_Rental : Rental
    {
        
        public double SecurityDeposit { get; set; }
        
        public Individual_Rental()
        {}


        public Individual_Rental(int contractNumber, string carLicensePlate, int clientId, DateTime contractDate, DateTime pickUp, DateTime returnCar, FOP formOfPayment, ContractStatus status, ContractType type, double secutiryDeposit) : base(contractNumber, carLicensePlate, clientId, contractDate, pickUp, returnCar, formOfPayment, status, type)
        {
            SecurityDeposit = secutiryDeposit;
        }

        Car_Register auxRegister = new Car_Register();         

        public int IndividualTax()
        {
            int tax = 10;

            if(auxRegister.FindByLicensePlate(CarLicensePlate).Category == CarCategory.Economic || auxRegister.FindByLicensePlate(CarLicensePlate).Category == CarCategory.Intermediary)
            {
                tax = 15;
            }

            return tax;
        }
        public override double TotalValue()
        {
            double total = auxRegister.FindByLicensePlate(CarLicensePlate).Rate * CheckPeriod();
            return  total + (total * IndividualTax() / 100);
        }

        public override string ToString()
        {
            return base.ToString()
                 + "\nSecutiry Depoist: $ " + SecurityDeposit;
        }
    }
}