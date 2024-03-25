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


        public Individual_Rental(int contractNumber, ContractType type, string carLicensePlate, int clientId, DateTime contractDate, DateTime pickUp, DateTime returnCar, FOP formOfPayment, ContractStatus status, Car_Register registerCar, double secutiryDeposit) : base(contractNumber,type, carLicensePlate, clientId, contractDate, pickUp, returnCar, formOfPayment, status, registerCar)
        {
            SecurityDeposit = secutiryDeposit;
        }

        public int IndividualTax()
        {
            int tax = 10;

            if(RegisterCar.FindByLicensePlate(CarLicensePlate).Category == CarCategory.Economic || RegisterCar.FindByLicensePlate(CarLicensePlate).Category == CarCategory.Intermediary)
            {
                tax = 15;
            }

            return tax;
        }
        public override double TotalValue()
        {
            double total = RegisterCar.FindByLicensePlate(CarLicensePlate).Rate * CheckPeriod(); // fix
            return  total + (total * IndividualTax() / 100);
        }

        public override string ToString()
        {
            return base.ToString()
                 + "Secutiry Depoist: $ " + SecurityDeposit;
        }
    }
}