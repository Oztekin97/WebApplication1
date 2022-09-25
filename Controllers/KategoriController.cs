using LibraryDataAccess.Data;
using LibraryModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ApplicationDbContext _db;
        public KategoriController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Kategori> objList = _db.Kategoriler.ToList();
            return View(objList);
        }
        public IActionResult Update_Insert(int? id)
        {
            Kategori obj = new Kategori();
            if (id == null)
            {
                return View(obj);
            }
            obj = _db.Kategoriler.FirstOrDefault(a => a.KategoriId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(Kategori obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.KategoriId == 0)
                {
                    //create işlemi
                    _db.Kategoriler.Add(obj);
                }
                else
                {
                    //update işlemi
                    _db.Kategoriler.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        public IActionResult Sil(int id)
        {
            var objDb = _db.Kategoriler.FirstOrDefault(a =>a.KategoriId==id);
            _db.Kategoriler.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CokluEkleme3()
        {
            List<Kategori> KategoriListesi = new List<Kategori>();
            for(int i = 1; i <= 3; i++)
            {
                KategoriListesi.Add(new Kategori { KategoriAd = Guid.NewGuid().ToString() });
            }
            _db.Kategoriler.AddRange(KategoriListesi);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CokluEkleme10()
        {
            List<Kategori> KategoriListesi = new List<Kategori>();
            for (int i = 1; i <= 10; i++)
            {
                KategoriListesi.Add(new Kategori { KategoriAd = Guid.NewGuid().ToString() });
            }
            _db.Kategoriler.AddRange(KategoriListesi);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CokluSilme3()
        {
            IEnumerable<Kategori> KategoriListesi = _db.Kategoriler.OrderByDescending(a=>a.KategoriId).Take(3).ToList();
            _db.Kategoriler.RemoveRange(KategoriListesi);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CokluSilme10()
        {
            IEnumerable<Kategori> KategoriListesi = _db.Kategoriler.OrderByDescending(a => a.KategoriId).Take(3).ToList();
            _db.Kategoriler.RemoveRange(KategoriListesi);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
