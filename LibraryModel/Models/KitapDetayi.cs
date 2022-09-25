using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Models
{
    public class KitapDetayi
    {
        [Key]
        public int KitapDetayId { get; set; }
        [Required]
        public int BolumSayisi { get; set; }
        public int KitapSayfaSayisi { get; set; }
        public double agirlik { get; set; }
        public Kitap Kitap { get; set; }
    }
}
