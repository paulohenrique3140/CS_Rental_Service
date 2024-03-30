using System;
using System.Collections.Generic;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities.Registers;
using CS_Rental_Service.Entities;
using System.Text;

namespace CS_Rental_Service.Entities.Registers
{
    class Client_Register : Register
    {
        public List<Client> ClientList { get; set; }

        public Client_Register()
        { }
        public Client_Register(string registerType) : base(registerType)
        {
            ClientList = new List<Client>();
        }


        public void AddClient(Client client)
        {
            ClientList.Add(client);
        }

        public void RemoveClient(int id)
        {
            ClientList.Remove(FindById(id));
        }

        public Client FindById(int id)
        {
            Client findedClient = new Individual();

            foreach (Client client in ClientList)
            {
                if (client.Id == id)
                {
                    findedClient = client;
                }
            }
            if (findedClient.Id == 0)
            {
                throw new DomainException("The customer with the entered ID was not found. Please try again!");
            }
            return findedClient;
        }

        public bool IsThereAClient(int id)
        {
            foreach (Client client in ClientList)
            {
                if (client.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Rental FindContract(int contractNumber)
        {
            Rental findedRental = new Individual_Rental();

            foreach (Client client in ClientList)
            {
                foreach (Rental rental in client.Contracts)
                {
                    if (rental.ContractNumber == contractNumber)
                    {
                        findedRental = rental;
                    }
                }
            }

            if (findedRental.CarLicensePlate is null)
            {
                throw new DomainException("Could not find a contract with the provided number! Please try again");
            }
            return findedRental;
        }

        public bool IsThereAContract(int contractNumber)
        {
            foreach (Client client in ClientList)
            {
                foreach (Rental rental in client.Contracts)
                {
                    if (rental.ContractNumber == contractNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void UpdateContractStatus(int contractNumber, ContractStatus newStatus)
        {
            FindContract(contractNumber).Status = newStatus;
        }

        public void ReturnCar(int contractNumber, Car_Register car_register)
        {

            FindContract(contractNumber).Status = ContractStatus.Closed;

            car_register.FindByLicensePlate(FindContract(contractNumber).CarLicensePlate).Availability = true;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Client client in ClientList)
            {
                sb.AppendLine(client.ToString());
            }
            return base.ToString()
                  + "\n" + sb.ToString();
        }
    }
}