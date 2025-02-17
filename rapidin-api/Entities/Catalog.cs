using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rapidin_api.Entities
{
    public class Catalog
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("brand")]
        public string brand { get; set; }

        [Column("model")]
        public string model { get; set; }

        [Column("description")]
        public string description { get; set; }
    }
}
