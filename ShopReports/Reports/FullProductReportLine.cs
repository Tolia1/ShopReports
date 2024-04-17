namespace ShopReports.Reports
{
    public class FullProductReportLine
    {
        public int ProductId { get; init; }

        public string Name { get; init; }

        public int CategoryId { get; init; }

        public string Category { get; init; }

        public string Manufacturer { get; init; }

        public decimal Price { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj is not FullProductReportLine)
            {
                return false;
            }

            var line = (FullProductReportLine)obj;

            return this.ProductId == line.ProductId &&
                this.Name == line.Name &&
                this.CategoryId == line.CategoryId &&
                this.Category == line.Category &&
                this.Manufacturer == line.Manufacturer &&
                this.Price == line.Price;
        }

        public override int GetHashCode()
        {
            return this.ProductId;
        }

        public override string ToString()
        {
            return $"{this.ProductId}|{this.Name}|{this.CategoryId}|{this.Category}|{this.Manufacturer}|{this.Price}";
        }
    }
}
