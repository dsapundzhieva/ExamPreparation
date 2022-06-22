using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>(capacity);
        }

        public List<Animal> Animals { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (this.Animals.Count >= this.Capacity)
            {
                return "The zoo is full.";
            }

            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = this.Animals.FindAll(x => x.Species == species).Count;

            if (count > 0)
            {
                this.Animals.RemoveAll(x => x.Species == species);
                return count;
            }
            return 0;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsList = this.Animals.Where(x => x.Diet == diet).ToList();

            return animalsList;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return this.Animals.FirstOrDefault(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = this.Animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength).Count;

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
