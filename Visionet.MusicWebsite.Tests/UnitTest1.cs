using System;
using System.Linq;
using Visionet.MusicWebsite.DAL;
using Xunit;

namespace Visionet.MusicWebsite.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            using(var db = new MusicContext())
            {
                var id = 2;
                var users = db.Users.Where(x => x.IdUser != id).ToList();
            }
        }
    }
}
