using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Models
{
    public class KitapYazar
    {
        [ForeignKey("Kitap")]
        public int KitapId { get; set; }
        [ForeignKey("Yazar")]
        public int YazarId { get; set; }
        public Kitap Kitap { get; set; }
        public Yazar Yazar { get; set; }
    }
}
