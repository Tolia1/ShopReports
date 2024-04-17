namespace ShopReports.Reports
{
    public class CustomerSalesRevenueReportLine
    {
        public int CustomerId { get; set; }

        public string PersonFirstName { get; init; }

        public string PersonLastName { get; init; }

        public double SalesRevenue { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj is not CustomerSalesRevenueReportLine)
            {
                return false;
            }

            var line = (CustomerSalesRevenueReportLine)obj;

            return this.CustomerId == line.CustomerId && this.PersonFirstName == line.PersonFirstName && this.PersonLastName == line.PersonLastName && this.SalesRevenue == line.SalesRevenue;
        }

        public override int GetHashCode()
        {
            return this.CustomerId.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.CustomerId}|{this.PersonLastName}|{this.PersonFirstName}|{this.SalesRevenue}";
        }
    }
}
