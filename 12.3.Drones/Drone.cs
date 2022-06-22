using System.Text;

namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public int Range { get; set; }

        public bool Available { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Drone: {this.Name}");
            stringBuilder.AppendLine($"Manufactured by: {this.Brand}");
            stringBuilder.Append($"Range: {this.Range} kilometers");

            return stringBuilder.ToString();
        }
    }
}
