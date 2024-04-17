using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using NUnit.Framework;

namespace ShopReports.Tests.Models
{
    public abstract class ModelTestBase<T>
        where T : class
    {
        private Type? classType;

        protected Type ClassType
        {
            get
            {
                return this.classType!;
            }
        }

        [SetUp]
        public void SetUp()
        {
            this.classType = typeof(T);
        }

        protected void AssertThatClassIsPublic(bool isSealed)
        {
            Assert.That(this.ClassType.IsClass, Is.True);
            Assert.That(this.ClassType.IsPublic, Is.True);
            Assert.That(this.ClassType.IsAbstract, Is.False);
            Assert.That(this.ClassType.IsSealed, isSealed ? Is.True : Is.False);
        }

        protected void AssertThatClassInheritsObject()
        {
            Assert.That(this.ClassType.BaseType, Is.EqualTo(typeof(object)));
        }

        protected PropertyInfo AssertThatClassHasProperty(string propertyName, Type expectedPropertyType, string columnName)
        {
            var propertyInfo = this.ClassType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.PropertyType, Is.EqualTo(expectedPropertyType));

            Assert.That(propertyInfo!.GetMethod!.IsPublic, Is.True);
            Assert.That(propertyInfo!.SetMethod!.IsPublic, Is.True);

            if (columnName is not null)
            {
                var columnAttribute = propertyInfo!.GetCustomAttribute<ColumnAttribute>();
                Assert.That(columnAttribute, Is.Not.Null);
                Assert.That(columnAttribute!.Name, Is.EqualTo(columnName));
            }

            return propertyInfo!;
        }

        protected void AssertThatHasTableAttribute(string tableName)
        {
            var tableAttribute = this.ClassType.GetCustomAttribute<TableAttribute>();
            Assert.That(tableAttribute, Is.Not.Null);
            Assert.That(tableAttribute!.Name, Is.EqualTo(tableName));
        }

        protected void AssertThatPropertyHasKeyAttribute(string propertyName)
        {
            var propertyInfo = this.ClassType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            Assert.That(propertyInfo, Is.Not.Null);

            var keyAttribute = propertyInfo!.GetCustomAttribute<KeyAttribute>();
            Assert.That(keyAttribute, Is.Not.Null);
        }

        protected void AssertThatPropertyHasForeignKeyAttribute(string propertyName, string navigationProperty)
        {
            var propertyInfo = this.ClassType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            Assert.That(propertyInfo, Is.Not.Null);

            var foreignKeyAttribute = propertyInfo!.GetCustomAttribute<ForeignKeyAttribute>();
            Assert.That(foreignKeyAttribute, Is.Not.Null);
            Assert.That(foreignKeyAttribute!.Name, Is.EqualTo(navigationProperty));
        }
    }
}
