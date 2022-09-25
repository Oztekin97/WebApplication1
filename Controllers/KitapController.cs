using LibraryDataAccess.Data;
using LibraryModel.Models;
using LibraryModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class KitapController : Controller
    {
        private readonly ApplicationDbContext _db;
        public KitapController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Kitap> objList = _db.Kitaplar.ToList();
            foreach (var obj in objList)
            {
                /* Uygulanabilir ama server açısından verimli değildir.
                   obj.YayinEvleri = _db.YayinEvleri.FirstOrDefault(a=>a.YayinEviId==obj.YayinEviId); */
                // uygulanabilir ve server açısından güvenli
                _db.Entry(obj).Reference(a => a.YayinEvleri).Load();
            }
            return View(objList);
        }
        public IActionResult Update_Insert(int? id)
        {
            KitapVM obj = new KitapVM();
            obj.YayinEviListesi = _db.YayinEvleri.Select(a => new SelectListItem
            {
                Text = a.YayinEviAd,
                Value=a.YayinEviId.ToString()
            }) ;
            if (id == null)
            {
                return View(obj);
            }
            //düzenleme
            obj.Kitap = _db.Kitaplar.FirstOrDefault(a => a.KitapId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(KitapVM obj)
        {
                if (obj.Kitap.KitapId == 0)
                {
                    //create işlemi
                    _db.Kitaplar.Add(obj.Kitap);
                }
                else
                {
                    //update işlemi
                    _db.Kitaplar.Update(obj.Kitap);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
        }
        public IActionResult Sil(int id)
        {
            var objDb = _db.Kitaplar.FirstOrDefault(a => a.KitapId == id);
            _db.Kitaplar.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detaylar(int? id)
        {
            KitapVM obj = new KitapVM();
            if (id == null)
            {
                return View(obj);
            }
            //düzenleme
            obj.Kitap = _db.Kitaplar.FirstOrDefault(a => a.KitapId == id);
            obj.Kitap.KitapDetayi = _db.KitapDetaylari.FirstOrDefault(a => a.KitapDetayId == obj.Kitap.KitapDetayId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detaylar(KitapVM obj)
        {
            if (obj.Kitap.KitapDetayi.KitapDetayId == 0)
            {
                //create işlemi
                _db.KitapDetaylari.Add(obj.Kitap.KitapDetayi);
                _db.SaveChanges();
                var kitapDB= _db.Kitaplar.FirstOrDefault(a => a.KitapId == obj.Kitap.KitapId);
                kitapDB.KitapDetayId = obj.Kitap.KitapDetayi.KitapDetayId;
                _db.SaveChanges();
            }
            else
            {
                //update işlemi
                _db.KitapDetaylari.Update(obj.Kitap.KitapDetayi);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ABC()
        {
            IQueryable<Kitap> kitapListesi2 = _db.Kitaplar;
            var filtreleme = kitapListesi2.Where(a => a.KitapAd != null).OrderBy(a => a.KitapAd).ToList();
            return View(filtreleme);
        }
    }
}
