using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AplikacjaInternetowa3.Models
{
    [Table("Kategorie")]
    public class Kategoria
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Nazwa { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Wydarzenie> Wydarzenia { get; set; }
    }
}
