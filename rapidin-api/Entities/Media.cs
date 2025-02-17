using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rapidin_api.Entities
{
    public class Media
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("id_catalog")]
        public int id_catalog { get; set; }

        [Column("link")]
        public string link { get; set; }
    }
}
