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
        
        public Company()
        {}

        public Company(int id, string name, string phonne, string email, Client_Register clientRegister, string cnpj) : base(id, name, phonne, email, clientRegister)
        {
            Cnpj = cnpj;
        }

        public override void AddContract(Rental rental, Client_Register client_register, Car_Register car_register)
        {
            base.AddContract(rental, client_register, car_register);
        }

        public override string ToString()
        {
            return base.ToString()
                  + " | CNPJ: " + Cnpj;
        }
    }
}