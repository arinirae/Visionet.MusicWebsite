﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Visionet.MusicWebsite.DAL;
using Visionet.MusicWebsite.Models;
using System.Data.Entity;
using Visionet.MusicWebsite.ViewModel;
using System.Data.Entity.Validation;

namespace Visionet.MusicWebsite.Controllers
{
    public class UserController : Controller
    {
        private MusicContext db;
        public UserController()
        {
            db = new MusicContext();
        }

        // GET: User
        public ActionResult Index(int? id)
        {
            var user = from c in db.Users
                       select c;
            return View(user);
        }
        
        public JsonResult GetCatatanMelaluiUserId(int IdUser)
        {
            db.Users.Where(user => user.IdUser == IdUser).ToList();
            throw new NotImplementedException("Belum selesai dibuat.");
        }

        public IList<User> GetCatatanByUserId(int IdUser)
        {
            return db.Users.Where(user => user.IdUser == IdUser).ToList();
        }

        public ActionResult GetCatatanJsonByUserId(int idUser)
        {
            var result = GetCatatanByUserId(idUser);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // DETAILS
        public ActionResult Details(int? id)
        {
            return View(new MusicVM
            {
                IdUser = id.Value
            });
        }
        
        private class Dto
        {
            public string Name { get; set; }
            public string FavMusic { get; set; }
        }

        public ActionResult AmbilDaftarTemanKecuali(int? id)
        {
            var result = db.Users.Where(x => x.IdUser != id).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AmbilTemanDenganMusikSama(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(404);

            var user = db.Users.Include(x => x.Friends).Include(v => v.Musics);

            var TemanDenganMusikSama = db.Database.SqlQuery<Dto>(@"
            SELECT 
                   teman.Name
                    ,musicTeman.FavMusic 
                FROM Users kamu
	                JOIN UserUsers uu
		                ON kamu.IdUser = uu.User_IdUser
	                JOIN Users teman 
		                ON teman.IdUser = uu.User_IdUser1
	                JOIN UserMusics um 
		                ON teman.IdUser = um.User_IdUser
	                JOIN Musics musicTeman
		                ON musicTeman.IdMusic = um.Music_IdMusic
                WHERE kamu.IdUser = {0}
	                AND IdMusic IN (
		                SELECT musikKamu.IdMusic
		                FROM Users kamu
		                JOIN UserMusics um
			                ON kamu.IdUser = um.User_IdUser
		                JOIN Musics musikKamu
			                ON musikKamu.IdMusic = um.Music_IdMusic
		                WHERE kamu.IdUser = {0}
	                )
            ORDER BY kamu.Name", id)
            .ToList()
            .GroupBy(x => x.FavMusic)
            .Select(x => new Dto
            {
                FavMusic = x.Key,
                Name = string.Join(", ", x.Select(v => v.Name))
            });

            return Json(TemanDenganMusikSama, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddFriend(int id)
        {
            var model = new UserVM();
            model.FriendList= db.Users.Where(x => x.IdUser != id)
                .Select(y => new UserVM
                {
                    IdUser = y.IdUser,
                    Name = y.Name
                });
            model.IdUser = id;
            return View(model);
        }

        public object createAjax(UserUsers userUsers)

        {

            var useruser = new UserUsers();
            useruser.User_IdUser = userUsers.User_IdUser;
            useruser.User_IdUser1 = userUsers.User_IdUser1;

            db.UserUsers.Add(useruser);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var showMessage = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .SelectMany(x => x.ErrorMessage);
            }
            return "success";
        }
    }
}