using System;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;

namespace CS_Rental_Service.Entities.Registers
{
    abstract class Register
    {
        public string RegisterType { get; set; }

        public Register(string registerType)
        {
            RegisterType = registerType;
        }

        public Register()
        {}

        public override string ToString()
        {
            return "\nRegister Type: " + RegisterType;
        }
    }
}