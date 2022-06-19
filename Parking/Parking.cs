using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Cars = new List<Car>();
            
        }

        public List<Car> Cars { get; set; }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => this.Cars.Count;

        public void Add(Car car)
        {
            if (this.Cars.Count < this.Capacity)
            {
                this.Cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.Cars.Any(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                Car car = this.Cars.Find(x => x.Manufacturer == manufacturer && x.Model == model);
                Cars.Remove(car);
                return true;
            }
            return false;
        }

        public Car GetLatestCar()
        {
            Car car = this.Cars.OrderByDescending(x => x.Year).FirstOrDefault();
            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = this.Cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            this.Cars.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString();
        }
    }

    
}
