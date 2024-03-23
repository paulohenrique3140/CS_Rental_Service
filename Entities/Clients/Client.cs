using System;
using System.Collections.Generic;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities;

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

        public override string ToString()
        {
            return "\nClient ID: " + Id
                + " | Phonne: " + Phonne
                + " | Email: " + Email;
        }
    }
}
