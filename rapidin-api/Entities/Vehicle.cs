using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rapidin_api.Entities
{
    public class Vehicle
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        
        [Column("id_enterprise")]
        public int id_enterprise { get; set; }

        [Column("id_catalog")]
        public int id_catalog { get; set; }

        [Column("color")]
        public string color { get; set; }

        [Column("state")]
        public bool state { get; set; }

        [Column("disponibility")]
        public bool disponibility { get; set; }

        [Column("mileage")]
        public double mileage { get; set; }
        
        [Column("cc")]
        public int cc { get; set; }

        [Column("engineHP")]
        public int engineHP { get; set; }

        [Column("price")]
        public double price { get; set; }

        [Column("likes")]
        public int likes { get; set; }
    }
}
