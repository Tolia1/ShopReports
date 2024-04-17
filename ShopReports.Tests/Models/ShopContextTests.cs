using System.Collections;
using NUnit.Framework;
using ShopReports.Models;

namespace ShopReports.Tests.Models
{
    [TestFixture]
    public sealed class ShopContextTests : IDisposable
    {
        private ShopContextFactory? factory;

        [SetUp]
        public void SetUp()
        {
            this.factory = new ShopContextFactory();
        }

        [TestCase(nameof(ShopContext.Categories), ExpectedResult = 6)]
        [TestCase(nameof(ShopContext.Products), ExpectedResult = 48)]
        [TestCase(nameof(ShopContext.Titles), ExpectedResult = 20)]
        [TestCase(nameof(ShopContext.Suppliers), ExpectedResult = 1)]
        [TestCase(nameof(ShopContext.Manufacturers), ExpectedResult = 6)]
        [TestCase(nameof(ShopContext.Cities), ExpectedResult = 5)]
        [TestCase(nameof(ShopContext.Locations), ExpectedResult = 15)]
        [TestCase(nameof(ShopContext.Supermarkets), ExpectedResult = 12)]
        [TestCase(nameof(ShopContext.SupermarketLocations), ExpectedResult = 15)]
        [TestCase(nameof(ShopContext.Persons), ExpectedResult = 30)]
        [TestCase(nameof(ShopContext.PersonContacts), ExpectedResult = 54)]
        [TestCase(nameof(ShopContext.ContactTypes), ExpectedResult = 4)]
        [TestCase(nameof(ShopContext.Customers), ExpectedResult = 20)]
        [TestCase(nameof(ShopContext.Orders), ExpectedResult = 50)]
        [TestCase(nameof(ShopContext.OrderDetails), ExpectedResult = 103)]
        public int TestDbSet_ReturnsCount(string dbSetName)
        {
            // Arrange
            var context = this.factory!.CreateContext();
            var dbSetProperty = context.GetType().GetProperty(dbSetName);

            // Act
            Assert.That(dbSetProperty, Is.Not.Null);
            var dbSet = dbSetProperty!.GetValue(context);

            // Assert
            IEnumerable enumerable = (IEnumerable)dbSet!;
            int count = (from object i in enumerable select i).Count();
            return count;
        }

        public void Dispose()
        {
            this.factory!.Dispose();
        }
    }
}
