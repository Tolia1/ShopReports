namespace ShopReports.Reports
{
    public sealed class ProductTitleSalesRevenueReport : ReportBase<ProductTitleSalesRevenueReportLine>
    {
        public ProductTitleSalesRevenueReport(IList<ProductTitleSalesRevenueReportLine> lines, DateTime reportGenerationDate)
            : base(lines, reportGenerationDate)
        {
        }
    }
}
