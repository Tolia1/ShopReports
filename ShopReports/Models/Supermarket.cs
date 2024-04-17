using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("supermarkets")]
    public class Supermarket
    {
        [Column("supermarket_id"), Key]
        public int Id { get; set; }
        [Column("supermarket_name")]
        public string Name { get; set; }

        public virtual IList<SupermarketLocation> Locations { get; set; }
    }
}
