using System;
using System.Collections.Generic;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Registers;
using CS_Rental_Service.Entities.Rentals;

namespace CS_Rental_Service.Entities.Clients
{
    class Individual : Client
    {
        public string Cpf { get; set; }
        
        public int LoyaltyPoints { get; set; }

        public Individual()
        { }

        public Individual(int id, string name, string phonne, string email, Client_Register clientRegister, string cpf) : base(id, name, phonne, email, clientRegister)
        {
            Cpf = cpf;
            LoyaltyPoints = 0;
        }
        
        

        public override void AddContract(Rental rental, Client_Register client_register, Car_Register car_register)
        {
            base.AddContract(rental, client_register, car_register);            
            
            Individual client = (Individual)client_register.FindById(rental.ClientId);            
            
            switch (car_register.FindByLicensePlate(rental.CarLicensePlate).Category)
            {
                case CarCategory.Economic:
                    client.LoyaltyPoints += 20;
                    break;
                case CarCategory.Intermediary:
                    client.LoyaltyPoints += 35;
                    break;
                case CarCategory.Special:
                    client.LoyaltyPoints += 50;
                    break;
                case CarCategory.SUV:
                    client.LoyaltyPoints += 80;
                    break;
                case CarCategory.Executive:
                    client.LoyaltyPoints += 100;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString()
                  + " | CPF: " + Cpf
                  + " | Loyalty Points: " + LoyaltyPoints;
        }
    }
}