using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6._3.CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            var hasSameIngrediant = Ingredients.Any(x => x.Name == ingredient.Name);

            if (!hasSameIngrediant && Ingredients.Count < Capacity && MaxAlcoholLevel >= ingredient.Alcohol)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                Ingredients.Remove(Ingredients.FirstOrDefault(x => x.Name == name));
                return true;
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public int CurrentAlcoholLevel
        {
            get { return Ingredients.Sum(x => x.Alcohol); }
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
