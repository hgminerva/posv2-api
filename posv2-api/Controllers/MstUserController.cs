using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/user")]
    public class MstUserController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstUser> listUsers()
        {
            var users = from d in db.MstUser
                    select new Models.PosMstUser
                    {
                        Id = d.Id,
                        UserName = d.UserName,
                        Password = d.Password,
                        FullName = d.FullName,
                        UserCardNumber = d.UserCardNumber,
                        EntryUserId = d.EntryUserId,
                        EntryDateTime = d.EntryDateTime,
                        UpdateUserId = d.UpdateUserId,
                        UpdateDateTime = d.UpdateDateTime,
                        IsLocked = d.IsLocked
                    };
            return users.ToList();
        }

        [HttpPost, Route("create")]
        public int addUser(Entity.MstUser user)
        {
            try
            {

                db.Entry(user).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return user.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editUser(Entity.MstUser user)
        {
            try
            {
                Entity.MstUser update = db.MstUser.Where(s => s.Id == user.Id).FirstOrDefault<Entity.MstUser>();

                if (update != null)
                {
                    update.UserName = user.UserName;
                    update.Password = user.Password;
                    update.FullName = user.FullName;
                    update.UserCardNumber = user.UserCardNumber;
                    update.EntryUserId = user.EntryUserId;
                    update.EntryDateTime = user.EntryDateTime;
                    update.UpdateUserId = user.UpdateUserId;
                    update.UpdateDateTime = user.UpdateDateTime;
                    update.IsLocked = user.IsLocked;
                }

                db.Entry(update).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return "Success";
            }
            catch
            {
                return "Error";
            }
        }

        [HttpDelete, Route("delete")]
        public String deleteUser(Entity.MstUser user)
        {
            try
            {
                Entity.MstUser delete = db.MstUser.Where(s => s.Id == user.Id).FirstOrDefault<Entity.MstUser>();

                db.Entry(delete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

                return "Success";
            }
            catch
            {
                return "Error";
            }
        }
    }
}
