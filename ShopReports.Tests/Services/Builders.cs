using System.Data.Common;
using ShopReports.Reports;

namespace ShopReports.Tests.Services
{
    public static class Builders
    {
        public static FullProductReportLine BuildFullProductReportLine(DbDataReader reader)
        {
            return new FullProductReportLine
            {
                ProductId = (int)reader.GetInt64(0),
                Name = reader.GetString(1),
                CategoryId = (int)reader.GetInt64(2),
                Manufacturer = reader.GetString(3),
                Price = reader.GetDecimal(4),
                Category = reader.GetString(5),
            };
        }

        public static ProductCategoryReportLine BuildProductCategoryReportLine(DbDataReader reader)
        {
            return new ProductCategoryReportLine
            {
                CategoryId = (int)reader.GetInt64(0),
                CategoryName = reader.GetString(1),
            };
        }

        public static ProductReportLine BuildProductReportLine(DbDataReader reader)
        {
            return new ProductReportLine
            {
                ProductId = (int)reader.GetInt64(0),
                ProductTitle = reader.GetString(1),
                Manufacturer = reader.GetString(2),
                Price = reader.GetDecimal(3),
            };
        }

        public static ProductTitleSalesRevenueReportLine BuildProductTitleSalesRevenueReportLine(DbDataReader reader)
        {
            return new ProductTitleSalesRevenueReportLine
            {
                ProductTitleName = reader.GetString(0),
                SalesRevenue = reader.GetDouble(1),
                SalesAmount = (int)reader.GetInt64(2),
            };
        }

        public static CustomerSalesRevenueReportLine BuildCustomerSalesRevenueReportLine(DbDataReader reader)
        {
            return new CustomerSalesRevenueReportLine
            {
                CustomerId = (int)reader.GetInt64(0),
                PersonFirstName = reader.GetString(1),
                PersonLastName = reader.GetString(2),
                SalesRevenue = reader.GetDouble(3),
            };
        }
    }
}
