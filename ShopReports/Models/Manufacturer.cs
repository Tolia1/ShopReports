using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("product_manufacturers")]
    public class Manufacturer
    {
        [Column("manufacturer_id"), Key]
        public int Id { get; set; }
        [Column("manufacturer_name")]
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
