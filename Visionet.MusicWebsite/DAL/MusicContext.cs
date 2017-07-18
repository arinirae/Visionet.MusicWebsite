using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Visionet.MusicWebsite.Models;

namespace Visionet.MusicWebsite.DAL
{
    public class MusicContext : DbContext
    {
        public MusicContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<UserUsers> UserUsers { get; set; }
        public DbSet<UserMusics> UserModels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MusicContext>(null);
            modelBuilder.Entity<User>().HasMany(m => m.Friends).WithMany(); //hasil tabel M:M
            modelBuilder.Entity<User>().HasMany(m => m.Musics).WithMany(); //hasil tabel M:M
            base.OnModelCreating(modelBuilder);
        }
    }
}