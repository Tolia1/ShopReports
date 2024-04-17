using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("customer_order_details")]
    public class OrderDetail
    {
        [Column("customer_order_detail_id"), Key]
        public int Id { get; set; }
        [Column("customer_order_id"), ForeignKey("Order")]
        public int OrderId { get; set; }
        [Column("product_id"), ForeignKey("Product")]
        public int ProductId { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("price_with_discount")]
        public double PriceWithDiscount { get; set; }
        [Column("product_amount")]
        public int ProductAmount { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
