namespace ShopReports.Reports
{
    public sealed class FullProductReport : ReportBase<FullProductReportLine>
    {
        public FullProductReport(IList<FullProductReportLine> lines, DateTime reportGenerationDate)
            : base(lines, reportGenerationDate)
        {
        }
    }
}
