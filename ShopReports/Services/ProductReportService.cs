using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services
{
    public class ProductReportService
    {
        private readonly ShopContext shopContext;

        public ProductReportService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public ProductCategoryReport GetProductCategoryReport()
        {
            var query = this.shopContext.Categories
                .Select(c => new ProductCategoryReportLine
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                })
                .OrderBy(c => c.CategoryName);
            IList<ProductCategoryReportLine> lines = query.ToList();
            ProductCategoryReport productCategoryReport = new ProductCategoryReport(lines, DateTime.Now);
            return productCategoryReport;
        }

        public ProductReport GetProductReport()
        {
            var query = this.shopContext.Products
                .Select(p => new ProductReportLine
                {
                    ProductId = p.Id,
                    ProductTitle = this.shopContext.Titles
                    .Where(t => t.Id == p.TitleId)
                    .Select(t => t.Title)
                    .First(),
                    Manufacturer = this.shopContext.Manufacturers
                    .Where(m => m.Id == p.ManufacturerId)
                    .Select(m => m.Name)
                    .First(),
                    Price = p.UnitPrice,
                })
                .OrderByDescending(p => p.ProductTitle);
            IList<ProductReportLine> lines = query.ToList();
            ProductReport productReport = new ProductReport(lines, DateTime.Now);
            return productReport;
        }

        public FullProductReport GetFullProductReport()
        {
            var query = this.shopContext.Products
                .Select(p => new FullProductReportLine
                {
                    ProductId = p.Id,
                    Name = this.shopContext.Titles
                    .Where(t => t.Id == p.TitleId)
                    .Select(t => t.Title)
                    .First(),
                    CategoryId = p.Title.CategoryId,
                    Category = this.shopContext.Categories
                    .Where(c => c.Id == p.Title.CategoryId)
                    .Select(c => c.Name)
                    .First(),
                    Manufacturer = this.shopContext.Manufacturers
                    .Where(m => m.Id == p.ManufacturerId)
                    .Select(m => m.Name)
                    .First(),
                    Price = p.UnitPrice,
                })
                .OrderBy(p => p.Name);
            IList<FullProductReportLine> lines = query.ToList();
            FullProductReport fullProductReport = new FullProductReport(lines, DateTime.Now);
            return fullProductReport;
        }

        public ProductTitleSalesRevenueReport GetProductTitleSalesRevenueReport()
        {
            var query = this.shopContext.Titles
                .Select(t => new ProductTitleSalesRevenueReportLine
                {
                    ProductTitleName = t.Title,
                    SalesRevenue = this.shopContext.OrderDetails
                    .Where(o => o.Product.TitleId == t.Id)
                    .Sum(o => o.PriceWithDiscount),
                    SalesAmount = this.shopContext.OrderDetails
                    .Where(o => o.Product.TitleId == t.Id)
                    .Sum(o => o.ProductAmount),
                })
                .Where(p => p.SalesAmount != 0)
                .OrderByDescending(p => p.SalesRevenue);
            IList<ProductTitleSalesRevenueReportLine> lines = query.ToList();
            ProductTitleSalesRevenueReport productTitleSalesRevenueReport = new ProductTitleSalesRevenueReport(lines, DateTime.Now);
            return productTitleSalesRevenueReport;
        }
    }
}
