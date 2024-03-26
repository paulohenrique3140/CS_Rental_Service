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
        {}
        public Client_Register(string registerType) : base(registerType)
        {
            ClientList = new List<Client>();
        }

        
        public void AddClient(Client client)
        {
            ClientList.Add(client);
        }

        public void RemoveClient(int id, ContractType type)
        {
            ClientList.Remove(findById(id, type));
        }

        public Client findById(int id, ContractType type)
        {
           Client findedClient = new Individual();

           foreach(Client client in ClientList)
           {
             if(client.Id == id)
             {
                if(type == ContractType.Individual)
                {
                    findedClient = client;
                }
                else 
                {
                    findedClient = (Company)client;
                }
             }
           }
           return findedClient;
        }
      

        public Rental findContract(int contractNumber, ContractType type)
        {
            Rental findedRental = new Individual_Rental();

            foreach(Client client in ClientList)
            {
                foreach(Rental rental in client.Contracts)
                {
                    if(rental.ContractNumber == contractNumber)
                    {
                        if(type == ContractType.Individual)
                        {
                            findedRental = rental;
                        }
                        else
                        {
                            findedRental = (Company_Rental)rental;
                        }
                    }
                }
            }
            return findedRental;
        }

        public void UpdateContractStatus(int contractNumber, ContractStatus newStatus, ContractType type)
        {
            findContract(contractNumber, type).Status = newStatus;
        }

        public void ReturnCar(int contractNumber, ContractType type, Car_Register car_register)
        {
            
            findContract(contractNumber, type).Status = ContractStatus.Closed;

            car_register.FindByLicensePlate(findContract(contractNumber, type).CarLicensePlate).Availability = true;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Client client in ClientList)
            {
                sb.AppendLine(client.ToString());
            }
            return base.ToString()
                  + "\n" + sb.ToString();
        }
    }
}