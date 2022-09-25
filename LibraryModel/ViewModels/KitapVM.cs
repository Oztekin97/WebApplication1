using LibraryModel.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.ViewModels
{
    public class KitapVM
    {
        public Kitap Kitap { get; set; }
        public IEnumerable<SelectListItem> YayinEviListesi { get; set; }
    }
}
