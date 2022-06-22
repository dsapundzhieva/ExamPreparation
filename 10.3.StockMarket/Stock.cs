using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string name, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.Name = name;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
            this.MarketCapitalization = pricePerShare * totalNumberOfShares;
        }

        public string Name { get; set; }

        public string Director { get; set; }

        public decimal PricePerShare { get; set; }

        public int TotalNumberOfShares { get; set; }

        public decimal MarketCapitalization { get; set; }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Company: {this.Name}");
            sb.AppendLine($"Director: {this.Director}");
            sb.AppendLine($"Price per share: ${this.PricePerShare}");
            sb.Append($"Market capitalization: ${this.MarketCapitalization}");

            return sb.ToString().TrimStart().TrimEnd();
        }

    }
}
