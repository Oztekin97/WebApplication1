using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Models
{
    [Table("Yazar")]
   public class Yazar
    {
        [Key]
        public int YazarId { get; set; }
        [Required]
        public string YazarAd { get; set; }
        [Required]
        public string YazarSoyad { get; set; }
        public string Lokasyon { get; set; }
        public DateTime dogumTarihi { get; set; }
        [NotMapped]
        public string AdSoyad
        {
            get {
                return $"{YazarAd} {YazarSoyad}";                   
                    }
        }
        public ICollection<KitapYazar> KitapYazarlar { get; set; }
    }
}
