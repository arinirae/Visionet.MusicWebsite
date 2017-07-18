using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visionet.MusicWebsite.ViewModel
{
    public class UserVM
    {
        public int? IdUser { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserVM> FriendList { get; set; }
    }
}