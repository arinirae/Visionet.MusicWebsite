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
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MusicContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}