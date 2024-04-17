using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services
{
    public class CustomerReportService
    {
        private readonly ShopContext shopContext;

        public CustomerReportService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public CustomerSalesRevenueReport GetCustomerSalesRevenueReport()
        {
            var query = this.shopContext.Customers
                .Select(c => new CustomerSalesRevenueReportLine
                {
                    CustomerId = c.Id,
                    PersonFirstName = this.shopContext.Persons
                    .Where(p => p.Id == c.Id)
                    .Select(p => p.FirstName)
                    .First(),
                    PersonLastName = this.shopContext.Persons
                    .Where(p => p.Id == c.Id)
                    .Select(p => p.LastName)
                    .First(),
                    SalesRevenue = this.shopContext.OrderDetails
                    .Where(o => o.Order.CustomerId == c.Id)
                    .Sum(o => o.PriceWithDiscount),
                })
                .Where(c => c.SalesRevenue != 0)
                .OrderByDescending(c => c.SalesRevenue);
            IList<CustomerSalesRevenueReportLine> lines = query.ToList();
            CustomerSalesRevenueReport customerSalesRevenueReport = new CustomerSalesRevenueReport(lines, DateTime.Now);
            return customerSalesRevenueReport;
        }
    }
}
