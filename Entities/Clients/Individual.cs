using System;
using System.Collections.Generic;

namespace CS_Rental_Service.Entities.Clients
{
    class Individual : Client
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public int LoyaltyPoints { get; set; }

        public Individual()
        {}

        public Individual(int id, string phonne, string email, string cpf, string name, int loyaltyPoints) : base(id, phonne, email)
        {
            Cpf = cpf;
            Name = name;
            LoyaltyPoints = loyaltyPoints;
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