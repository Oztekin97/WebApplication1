using LibraryDataAccess.Data;
using LibraryModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class YayinEviController : Controller
    {
        private readonly ApplicationDbContext _db;
        public YayinEviController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<YayinEvi> objList = _db.YayinEvleri.ToList();
            return View(objList);
        }
        public IActionResult Update_Insert(int? id)
        {
            YayinEvi obj = new YayinEvi();
            if (id == null)
            {
                return View(obj);
            }
            obj = _db.YayinEvleri.FirstOrDefault(a => a.YayinEviId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update_Insert(YayinEvi obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.YayinEviId == 0)
                {
                    //create işlemi
                    _db.YayinEvleri.Add(obj);
                }
                else
                {
                    //update işlemi
                    _db.YayinEvleri.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        public IActionResult Sil(int id)
        {
            var objDb = _db.YayinEvleri.FirstOrDefault(a => a.YayinEviId == id);
            _db.YayinEvleri.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
