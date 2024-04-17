namespace ShopReports.Reports
{
    public sealed class ProductCategoryReport : ReportBase<ProductCategoryReportLine>
    {
        public ProductCategoryReport(IList<ProductCategoryReportLine> lines, DateTime reportGenerationDate)
            : base(lines, reportGenerationDate)
        {
        }
    }
}
