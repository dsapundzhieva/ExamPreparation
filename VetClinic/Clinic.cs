using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            PetsData = new List<Pet>();
        }

        public List<Pet> PetsData { get; set; }

        public int Capacity { get; set; }

        public int Count => PetsData.Count;
        public void Add(Pet pet)
        {
            if (PetsData.Count < Capacity)
            {
                PetsData.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (PetsData.Any(x => x.Name == name))
            {
                Pet pet = PetsData.Find(x => x.Name == name);
                PetsData.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            return PetsData.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return PetsData.OrderByDescending(x => x.Age).First();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in PetsData)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString();
        }
    }
}
