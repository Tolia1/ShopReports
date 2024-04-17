using NUnit.Framework;
using ShopReports.Models;
using ShopReports.Services;

namespace ShopReports.Tests.Services
{
    public class ReportServiceBaseTests<T> : IDisposable
        where T : class
    {
        protected ShopContextFactory Factory { get; private set; }

        protected T Service { get; set; }

        public void SetUp()
        {
            this.Factory = new ShopContextFactory();
        }

        public void ReportService_ReturnsCorrectReportLines(string methodName, Func<T, IReadOnlyList<object>> getActualLines, Func<ShopContextFactory, IReadOnlyList<object>> getExpectedLines)
        {
            // Arrange
            var expected = getExpectedLines(this.Factory);

            // Act
            var actual = getActualLines(this.Service);

            // Assert
            var errorMsg = $"Class: ProductReportService {Environment.NewLine}  Method {methodName} returns report";
            var dataSetErrorMsg = errorMsg + $" that actual data {Environment.NewLine}{actual.ConvertToString()}   are not equals to expected data {Environment.NewLine}{expected.ConvertToString()}";
            Assert.AreEqual(expected, actual, dataSetErrorMsg);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Factory!.Dispose();
            }
        }
    }
}
