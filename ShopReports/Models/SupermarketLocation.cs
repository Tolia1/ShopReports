using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("supermarket_locations")]
    public class SupermarketLocation
    {
        [Column("supermarket_location_id"), Key]
        public int Id { get; set; }
        [Column("supermarket_id"), ForeignKey("Supermarket")]
        public int SupermarketId { get; set; }
        [Column("location_id"), ForeignKey("Location")]
        public int LocationId { get; set; }

        public Supermarket Supermarket { get; set; }

        public Location Location { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}
