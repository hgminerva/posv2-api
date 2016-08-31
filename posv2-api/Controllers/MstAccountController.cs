using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/acount")]
    public class MstAccountController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstAccount> listAccounts()
        {
            var accounts = from d in db.MstAccount
                           select new Models.PosMstAccount
                           {
                               Id = d.Id,
                               Code = d.Code,
                               Account = d.Account,
                               IsLocked = d.IsLocked,
                               AccountType = d.AccountType

                           };

            return accounts.ToList();
        }

        [HttpPost, Route("create")]
        public int addAccount(Entity.MstAccount account)
        {
            try
            {

                db.Entry(account).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return account.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editAccount(Entity.MstAccount account)
        {
            try
            {
                Entity.MstAccount update = db.MstAccount.Where(s => s.Id == account.Id).FirstOrDefault<Entity.MstAccount>();

                if (update != null)
                {
                    update.Code = account.Code;
                    update.Account = account.Account;
                    update.IsLocked = account.IsLocked;
                    update.AccountType = account.AccountType;
                    
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
        public String deleteAccount(Entity.MstAccount account)
        {
            try
            {
                Entity.MstAccount delete = db.MstAccount.Where(s => s.Id == account.Id).FirstOrDefault<Entity.MstAccount>();

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
