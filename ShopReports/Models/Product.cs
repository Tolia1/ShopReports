using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("shop_products")]
    public class Product
    {
        [Column("product_id"), Key]
        public int Id { get; set; }
        [Column("product_title_id"), ForeignKey("Title")]
        public int TitleId { get; set; }
        [Column("product_manufacturer_id"), ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        [Column("product_supplier_id"), ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        [Column("unit_price")]
        public decimal UnitPrice { get; set; }
        [Column("comment")]
        public string Description { get; set; }

        public ProductTitle Title { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public Supplier Supplier { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}
