using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rapidin_api.Entities
{
    public class Enterprise
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        
        [Column("name")]
        public string name { get; set; }
    }
}
