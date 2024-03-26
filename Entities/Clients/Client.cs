using System;
using System.Collections.Generic;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;
using CS_Rental_Service.Entities.Registers;
using System.Text;

namespace CS_Rental_Service.Entities.Clients
{
    abstract class Client
    {
        public int Id { get; }
        public string Phonne { get; set; }
        public string Email { get; set; }
        public List<Rental> Contracts { get; }

        public Client()
        { }

        public Client(int id, string phonne, string email)
        {
            Id = id;
            Phonne = phonne;
            Email = email;
            Contracts = new List<Rental>();
        }
        
        public virtual void AddContract(Rental rental, Client_Register client_register, Car_Register car_register)
        {
            client_register.findById(rental.ClientId, rental.Type).Contracts.Add(rental);

            car_register.FindByLicensePlate(rental.CarLicensePlate).Availability = false;
            
            client_register.UpdateContractStatus(rental.ContractNumber, ContractStatus.Open, rental.Type);
        }

        public override string ToString()
        {
            return "\nClient ID: " + Id
                + " | Phonne: " + Phonne
                + " | Email: " + Email;
        }

        public string GetClientContracts()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Rental contract in Contracts)
            {
                sb.AppendLine(contract.ToString());
            }
            return sb.ToString();
        }
    }
}
