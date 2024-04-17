using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("customers")]
    public class Customer
    {
        [Column("customer_id"), Key, ForeignKey("Person")]
        public int Id { get; set; }
        [Column("card_number")]
        public string CardNumber { get; set; }
        [Column("discount")]
        public decimal Discount { get; set; }

        public Person Person { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}
