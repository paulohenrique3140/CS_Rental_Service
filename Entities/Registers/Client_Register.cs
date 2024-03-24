using System;
using System.Collections.Generic;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities.Registers;
using CS_Rental_Service.Entities;

namespace CS_Rental_Service.Entities.Registers
{
    class Client_Register : Register
    {
        public List<Client> ClientList { get; set; }

        public Client_Register()
        {}
        public Client_Register(string registerType) : base(registerType)
        {
            ClientList = new List<Client>();
        }

        Car_Register auxCar = new Car_Register();

        public void AddClient(Client client)
        {
            ClientList.Add(client);
        }

        public void RemoveClient(int id, string type)
        {
            ClientList.Remove(findById(id, type));
        }

        public Client findById(int id, string type)
        {
            Client findedIndividualClient = new Individual();
            Client findedCompanyClient = new Company();
            
            if (type == "Individual")
            {
                foreach(Client client in ClientList)
                {
                    if(client.Id == id)
                    {
                        if (type == "Individual")
                        {
                            findedIndividualClient = client;
                        }
                        else
                        {
                            findedCompanyClient = client;
                        }
                    }
                }
            }

            if (type == "Individual")
            {
                return findedIndividualClient;
            }

            return findedCompanyClient;
        }

        

        public Rental findContract(int contractNumber, string type)
        {
            Rental findedCompanyRental = new Company_Rental();
            Rental findedIndividualRental = new Individual_Rental();

            foreach(Client client in ClientList)
            {
                foreach(Rental rental in client.Contracts)
                {
                    if(rental.ContractNumber == contractNumber)
                    {
                        if (type == "Company") {
                            findedCompanyRental = rental;
                        } 
                        else
                        {
                            findedIndividualRental = rental;
                        }
                    }
                }
            }

            if (type == "Individual")
            {
                return findedIndividualRental;
            }

            return findedCompanyRental;
        }

        public void UpdateContractStatus(int contractNumber, ContractStatus newStatus, ContractType type)
        {
            Rental findedContract = findContract(contractNumber, type.ToString());
            findedContract.Status = newStatus;
        }

        public void ReturnCar(int contractNumber, ContractType type)
        {
            Rental findedContract = findContract(contractNumber, type.ToString());
            findedContract.Status = ContractStatus.Closed;

            Car findedCar = new Car();
            findedCar = auxCar.FindByLicensePlate(findedContract.CarLicensePlate);
            findedCar.Availability = true;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}