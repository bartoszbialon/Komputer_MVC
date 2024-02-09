using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{

    [Table("computers")]
    public class ComputerEntity
    {
        [Key]
        public int ComputerId { get; set; }

        [Column("Nazwa komputera")]
        [MinLength(10)]
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [Column("Procesor")]
        [MinLength(7)]
        [MaxLength(90)]
        [Required]
        public string Processor { get; set; }

        [Column("Pamięć RAM")]
        [MinLength(7)]
        [MaxLength(90)]
        [Required]
        public string Memory { get; set; }

        [Column("Dysk twardy")]
        [MinLength(10)]
        [MaxLength(120)]
        [Required]
        public string HardDrive { get; set; }

        [Column("Karta graficzna")]
        [MinLength(10)]
        [MaxLength(90)]
        [Required]
        public string GraphicsCard { get; set; }

        [Column("Data produkcji")]
        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public TypeEntity? Type { get; set; }

        [Required]
        public int ProducerId { get; set; }

        [Required]
        public ProducerEntity? Producer { get; set; }
    }
}
