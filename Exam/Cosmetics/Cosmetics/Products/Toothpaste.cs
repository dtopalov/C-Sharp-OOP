namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IProduct, IToothpaste
    {
        private IList<string> ingredientsList;
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredientsList):
            base(name, brand, price, gender)
        {
            this.IngredientsList = ingredientsList;
            this.ingredients = string.Empty;
        }

        public string Ingredients
        {
            get { return string.Join(", ", this.ingredientsList); }
            set
            {
                foreach (var item in this.ingredientsList)
                {
                    Validator.CheckIfStringIsNullOrEmpty(value, "Ingredient name cannot be null or empty!");
                    Validator.CheckIfStringLengthIsValid(value, 12, 4, string.Format("Each ingredient must be between {0} and {1} symbols long!", 4, 12));
                }
                this.ingredients = string.Join(", ", this.ingredientsList);
            }
        }

        public IList<string> IngredientsList
        {
            get { return this.ingredientsList; }
            set
            {
                Validator.CheckIfNull(value, "List of ingredients cannot be null");
                this.ingredientsList = value;
            }
        }

        public override string Print()
        {
            return (base.Print() + string.Format("{0}  * Ingredients: {1}", Environment.NewLine, this.Ingredients)).TrimEnd();
        }
    }
}
