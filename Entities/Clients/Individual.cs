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
        
        Car auxCar = new Car();

        public override void AddContract(Rental rental, Client_Register client_register, Car_Register car_register)
        {
            Client clientToAddContract = client_register.findById(rental.ClientId, rental.Type.ToString());
            clientToAddContract.Contracts.Add(rental);

            
            Car findedCar = new Car();
            findedCar = car_register.FindByLicensePlate(rental.CarLicensePlate);
            findedCar.Availability = false;
            
            client_register.UpdateContractStatus(rental.ContractNumber, ContractStatus.Open, rental.Type);
            
            switch (findedCar.Category)
            {
                case CarCategory.Economic:
                    LoyaltyPoints += 20;
                    break;
                case CarCategory.Intermediary:
                    LoyaltyPoints += 35;
                    break;
                case CarCategory.Special:
                    LoyaltyPoints += 50;
                    break;
                case CarCategory.Suv:
                    LoyaltyPoints += 80;
                    break;
                case CarCategory.Executive:
                    LoyaltyPoints += 100;
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