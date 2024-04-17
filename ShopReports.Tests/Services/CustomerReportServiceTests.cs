using NUnit.Framework;
using ShopReports.Services;

namespace ShopReports.Tests.Services
{
    [TestFixture]
    public sealed class CustomerReportServiceTests : ReportServiceBaseTests<CustomerReportService>
    {
        private static readonly object[][] TestContainer = new object[][]
        {
            new object[] { "GetCustomerSalesRevenueReport", (CustomerReportService service) => service.GetCustomerSalesRevenueReport().Lines, (ShopContextFactory factory) => factory.GetEntitiesBySqlQueryName("GetCustomerSalesRevenueReport", Builders.BuildCustomerSalesRevenueReportLine), },
        };

        [SetUp]
        public new void SetUp()
        {
            base.SetUp();
            this.Service = new CustomerReportService(this.Factory.CreateContext());
        }

        [TestCaseSource(nameof(TestContainer))]
        public new void ReportService_ReturnsCorrectReportLines(string methodName, Func<CustomerReportService, IReadOnlyList<object>> getActualLines, Func<ShopContextFactory, IReadOnlyList<object>> getExpectedLines)
        {
            base.ReportService_ReturnsCorrectReportLines(methodName, getActualLines, getExpectedLines);
        }
    }
}
