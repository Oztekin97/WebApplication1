using LibraryModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccess.Data
{
   public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<YayinEvi> YayinEvleri { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<KitapDetayi> KitapDetaylari { get; set; }
        public DbSet<KitapYazar> KitapYazarlar { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KitapYazar>().HasKey(x => new { x.YazarId, x.KitapId });
        }
    }
}
