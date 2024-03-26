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
        public string Name { get; set; }
        public int LoyaltyPoints { get; set; }

        public Individual()
        { }

        public Individual(int id, string phonne, string email, string cpf, string name, int loyaltyPoints) : base(id, phonne, email)
        {
            Cpf = cpf;
            Name = name;
            LoyaltyPoints = loyaltyPoints;
        }
        
        

        public override void AddContract(Rental rental, Client_Register client_register, Car_Register car_register)
        {
            base.AddContract(rental, client_register, car_register);            
            
            Individual client = (Individual)client_register.findById(rental.ClientId, rental.Type);            
            
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
                case CarCategory.Suv:
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
                  + " | Name: " + Name
                  + " | Loyalty Points: " + LoyaltyPoints;
        }
    }
}