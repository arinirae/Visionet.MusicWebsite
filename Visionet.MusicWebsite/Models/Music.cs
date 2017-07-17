using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Visionet.MusicWebsite.Models
{
    public class Music
    {
        [Key]
        public int? IdMusic { get; set; }
        public string FavMusic { get; set; }
        public virtual User Users { get; set; }
        public int? IdUser { get; set; }
    }
}