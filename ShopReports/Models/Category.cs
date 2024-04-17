using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("product_categories")]
    public class Category
    {
        [Column("category_id"), Key]
        public int Id { get; set; }
        [Column("category_name")]
        public string Name { get; set; }

        public virtual IList<ProductTitle> Titles { get; set; }
    }
}
