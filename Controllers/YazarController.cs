using LibraryDataAccess.Data;
using LibraryModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class YazarController : Controller
    {
        private readonly ApplicationDbContext _db;
        public YazarController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Yazar> objList = _db.Yazarlar.ToList();
            return View(objList);
        }
        public IActionResult Update_Insert(int? id)
        {
            Yazar obj = new Yazar();
            if (id == null)
            {
                return View(obj);
            }
            obj = _db.Yazarlar.FirstOrDefault(a => a.YazarId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(Yazar obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.YazarId == 0)
                {
                    //create işlemi
                    _db.Yazarlar.Add(obj);
                }
                else
                {
                    //update işlemi
                    _db.Yazarlar.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        public IActionResult Sil(int id)
        {
            var objDb = _db.Yazarlar.FirstOrDefault(a => a.YazarId == id);
            _db.Yazarlar.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
