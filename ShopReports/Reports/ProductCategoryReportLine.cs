namespace ShopReports.Reports
{
    public class ProductCategoryReportLine
    {
        public int CategoryId { get; init; }

        public string CategoryName { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj is not ProductCategoryReportLine)
            {
                return false;
            }

            var line = (ProductCategoryReportLine)obj;

            return this.CategoryId == line.CategoryId && this.CategoryName == line.CategoryName;
        }

        public override int GetHashCode()
        {
            return this.CategoryId;
        }

        public override string ToString()
        {
            return $"{this.CategoryId}|{this.CategoryName}";
        }
    }
}
