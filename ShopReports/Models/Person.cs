using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("persons")]
    public class Person
    {
        [Column("person_id"), Key]
        public int Id { get; set; }
        [Column("person_first_name")]
        public string FirstName { get; set; }
        [Column("person_last_name")]
        public string LastName { get; set; }
        [Column("person_birth_date")]
        public string BirthDate { get; set; }

        public virtual IList<PersonContact> Contacts { get; set; }

        public Customer Customer { get; set; }
    }
}
