using System.Collections;
using System.Text;

namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string regNumber, ICollection<IFurniture> catalogOfFurnitures = null)
        {
            this.Name = name;
            this.RegistrationNumber = regNumber;
            this.Furnitures = catalogOfFurnitures ?? new Collection<IFurniture>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new IndexOutOfRangeException("Company name cannot be null, empty, or shorter than 5 symbols");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                if (!ValidRegistrationNumber(value))
                {
                    throw new ArgumentException("Registration number is not in the correct format");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(this.furnitures); }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Furnitures collection cannot be null");
                }
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(x => x.Model.ToLower().Equals(model.ToLower()));
        }

        public string Catalog()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));
            var sortedFurnitures = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);

            if (sortedFurnitures.Any())
            {
                result.Append(string.Join(Environment.NewLine, sortedFurnitures));    
            }
            
            return result.ToString();
        }

        private bool ValidRegistrationNumber(string regNumber)
        {
            if (string.IsNullOrEmpty(regNumber) || regNumber.Length != 10)
            {
                return false;
            }
            if (regNumber.Any(symbol => !Char.IsDigit(symbol)))
            {
                return false;
            }
            return true;
        }
    }
}
