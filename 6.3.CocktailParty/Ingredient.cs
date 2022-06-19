using System;
using System.Collections.Generic;
using System.Text;

namespace _6._3.CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Ingredient: {Name}");
            stringBuilder.AppendLine($"Quantity: {Quantity}");
            stringBuilder.Append($"Alcohol: {Alcohol}");
            return stringBuilder.ToString();
        }
    }
}
