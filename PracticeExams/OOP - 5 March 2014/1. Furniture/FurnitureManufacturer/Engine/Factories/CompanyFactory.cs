using System;

namespace FurnitureManufacturer.Engine.Factories
{
    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            //Console.WriteLine("Company {0} created", name);
            return new Company(name, registrationNumber);
        }
    }
}
