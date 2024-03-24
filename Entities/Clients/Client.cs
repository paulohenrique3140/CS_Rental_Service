using System;
using System.Collections.Generic;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;
using CS_Rental_Service.Entities.Registers;

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
        Client_Register auxRegister = new Client_Register();
        Car_Register auxCar = new Car_Register();
        public virtual void AddContract(Rental rental)
        {
            Client clientToAddContract = auxRegister.findById(rental.ClientId, rental.Type.ToString());
            clientToAddContract.Contracts.Add(rental);

            
            Car findedCar = new Car();
            findedCar = auxCar.FindByLicensePlate(rental.CarLicensePlate);
            findedCar.Availability = false;
            
            auxRegister.UpdateContractStatus(rental.ContractNumber, ContractStatus.Open, rental.Type);
        }

        public override string ToString()
        {
            return "\nClient ID: " + Id
                + " | Phonne: " + Phonne
                + " | Email: " + Email;
        }
    }
}
