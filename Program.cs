using System;

using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;

namespace CS_Rental_Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Client iclient = new Individual(24, "119934069298", "email@email", "40675162823", "Paulo Henrique", 45);
            Console.WriteLine(iclient);

            Client cclient = new Company(25, "114484498489", "company@company.com", "005151515545/0001", "Industrias Calixto");
            Console.WriteLine(cclient);
        }
    }
}

