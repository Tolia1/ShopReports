using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("customer_orders")]
    public class Order
    {
        [Column("customer_order_id"), Key]
        public int Id { get; set; }
        [Column("operation_time")]
        public string OperationTime { get; set; }
        [Column("supermarket_location_id"), ForeignKey("SupermarketLocation")]
        public int SupermarketLocationId { get; set; }
        [Column("customer_id"), ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public SupermarketLocation SupermarketLocation { get; set; }

        public Customer? Customer { get; set; }

        public virtual IList<OrderDetail> Details { get; set; }
    }
}
