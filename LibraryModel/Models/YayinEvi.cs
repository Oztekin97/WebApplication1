using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Models
{
    [Table("YayinEvi")]
    public class YayinEvi
    {
        [Key]
        public int YayinEviId { get; set; }
        [Required]
        public string YayinEviAd { get; set; }
        [Required]
        public string BasimYeri { get; set; }
        public List<Kitap> Kitap { get; set; }
    }
}
