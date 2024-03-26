using System;
using System.Collections.Generic;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;
using CS_Rental_Service.Entities.Registers;
namespace CS_Rental_Service.Entities.Clients
{
    class Company : Client
    {
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }

        public Company()
        {}

        public Company(int id, string phonne, string email, string cnpj, string companyName) : base(id, phonne, email)
        {
            Cnpj = cnpj;
            CompanyName = companyName;
        }

        public override void AddContract(Rental rental, Client_Register client_register, Car_Register car_register)
        {
            base.AddContract(rental, client_register, car_register);
        }

        public override string ToString()
        {
            return base.ToString()
                  + " | CNPJ: " + Cnpj
                  + " | Company Name: " + CompanyName;
        }
    }
}