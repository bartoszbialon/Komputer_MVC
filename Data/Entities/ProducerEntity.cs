using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProducerEntity
    {
        [Key]
        public int ProducerId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(58)]
        public string OriginCountry { get; set; }

        [Required]
        public DateTime FoundationYear { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(80)]
        public string Street { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(60)]
        public string City { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string PostalCode { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Region { get; set; }

        public ISet<ComputerEntity> Computers { get; set; } 

        

    }
}
