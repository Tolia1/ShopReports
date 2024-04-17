namespace ShopReports.Reports
{
    public class ProductReportLine
    {
        public int ProductId { get; init; }

        public string ProductTitle { get; init; }

        public string Manufacturer { get; init; }

        public decimal Price { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj is not ProductReportLine)
            {
                return false;
            }

            var line = (ProductReportLine)obj;

            return this.ProductId == line.ProductId &&
                this.ProductTitle == line.ProductTitle &&
                this.Manufacturer == line.Manufacturer &&
                this.Price == line.Price;
        }

        public override int GetHashCode()
        {
            return this.ProductId;
        }

        public override string ToString()
        {
            return $"{this.ProductId}|{this.ProductTitle}|{this.Manufacturer}|{this.Price}";
        }
    }
}
