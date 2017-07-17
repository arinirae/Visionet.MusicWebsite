using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Visionet.MusicWebsite.Models
{
    public class User
    {
        [Key]
        public int? IdUser { get; set; }        
        public string Name { get; set; }
        public ICollection<User>Friends { get; set; }
        public ICollection<Music>Musics { get; set; }
    }
}