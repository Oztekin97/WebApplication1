using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Models
{
    [Table("Kitap")]
    public class Kitap
    {
        [Key]
        public int KitapId { get; set; }
        [Required]
        public string KitapAd { get; set; }
        [Required]
        public double Fiyat { get; set; }
        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; }
       // [ForeignKey("Kategori")]
       // public int KategoriId { get; set; }
       // public Kategori Kategori { get; set; }
        [ForeignKey("KitapDetayi")]
        public int? KitapDetayId { get; set; }
        public KitapDetayi KitapDetayi { get; set; }
        [ForeignKey("YayinEvi")]
        public int YayinEviId { get; set; }
        public YayinEvi YayinEvleri { get; set; }
        public ICollection<KitapYazar> KitapYazarlar { get; set; }
    }
}
