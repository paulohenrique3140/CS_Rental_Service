using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS_Rental_Service.Entities.Clients
{
    class Company : Client
    {
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }

        public Company()
        {}

        public Company(int id, string phonne, string email, string cnpj, string companyName) : base(id, phonne, email)
        {
            Cnpj = cnpj;
            CompanyName = companyName;
        }

        public override string ToString()
        {
            return base.ToString()
                  + " | CNPJ: " + Cnpj
                  + " | Company Name: " + CompanyName;
        }
    }
}