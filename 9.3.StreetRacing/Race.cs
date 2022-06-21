using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>(capacity);
        }

        public List<Car> Participants { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            bool hasAlreadySuchLicensePlate = this.Participants.Any(x => x.LicensePlate == car.LicensePlate);

            if (!hasAlreadySuchLicensePlate && this.Count < this.Capacity && car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (this.Participants.Any(x => x.LicensePlate == licensePlate))
            {
                Car car = this.Participants.First(x => x.LicensePlate == licensePlate);
                this.Participants.Remove(car);
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return this.Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
