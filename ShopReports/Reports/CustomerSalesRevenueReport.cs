namespace ShopReports.Reports
{
    public sealed class CustomerSalesRevenueReport : ReportBase<CustomerSalesRevenueReportLine>
    {
        public CustomerSalesRevenueReport(IList<CustomerSalesRevenueReportLine> lines, DateTime reportGenerationDate)
            : base(lines, reportGenerationDate)
        {
        }
    }
}
