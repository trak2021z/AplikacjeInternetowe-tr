using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    [Table("Wydarzenia")]
    public class Wydarzenie
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public DateTime Data_wydarzenia { get; set; }
        [StringLength(50)]
        public string Opis { get; set; }
    }
}
