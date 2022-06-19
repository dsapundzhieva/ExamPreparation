using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._3.TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Racers = new List<Racer>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Racer> Racers { get; set; }

        public void Add(Racer racer)
        {
            if (Count < Capacity)
            {
                Racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if (Racers.Any(x => x.Name == name))
            {
                Racer racer = Racers.FirstOrDefault(x => x.Name == name);
                Racers.Remove(racer);
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            return Racers.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return Racers.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            Racer racer = Racers.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
            return racer;
        }

        public int Count => Racers.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in Racers)
            {
                sb.AppendLine($"Racer: {racer.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
