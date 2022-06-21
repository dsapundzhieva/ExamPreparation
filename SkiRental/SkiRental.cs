using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Skies = new List<Ski>(capacity);
        }

        public List<Ski> Skies { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Ski ski)
        {
            if (this.Count < this.Capacity)
            {
                this.Skies.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.Skies.Any(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                Ski ski = this.Skies.First(x => x.Manufacturer == manufacturer && x.Model == model);
                this.Skies.Remove(ski);
                return true;
            }
            return false;
        }

        public Ski GetNewestSki()
        {
            return this.Skies.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return this.Skies.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int Count => this.Skies.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in this.Skies)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString();
        }
    }
}
