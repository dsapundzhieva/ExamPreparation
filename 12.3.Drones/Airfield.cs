using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>(capacity);
        }

        public List<Drone> Drones { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (this.Count < this.Capacity)
            {
                if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
                {
                    return "Invalid drone.";
                }
                else
                {
                    this.Drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
            }
            else
            {
                return "Airfield is full.";
            }
        }

        public bool RemoveDrone(string name)
        {
            if (this.Drones.Any(x => x.Name == name))
            {
                Drone drone = this.Drones.FirstOrDefault(x => x.Name == name);
                this.Drones.Remove(drone);
                return true;
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = this.Drones.Where(x => x.Brand == brand).Count();
            if (count > 0)
            {
                this.Drones.RemoveAll(x => x.Brand == brand);
                return count;
            }
            return 0;
        }

        public Drone FlyDrone(string name)
        {
            if (this.Drones.Any(x => x.Name == name))
            {
                Drone drone = this.Drones.First(x => x.Name == name);
                drone.Available = false;
                return drone;
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var list = new List<Drone>();
            foreach (var drone in this.Drones)
            {
                if (drone.Range == range)
                {
                    drone.Available = false;
                    list.Add(drone);
                }
            }
            return list;
        }

        public string Report()
        {
            List<Drone> drones = new List<Drone>();
            foreach (var drone in this.Drones)
            {
                if (drone.Available == true)
                {
                    drones.Add(drone);
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in drones)
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
