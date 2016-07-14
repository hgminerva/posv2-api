using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/payType")]
    public class MstPayTypeController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstPayType> listPayTypes()
        {
            var payTypes = from d in db.MstPayType
                         select new Models.PosMstPayType
                              {
                                  Id = d.Id,
                                  PayType = d.PayType,
                                  AccountId = d.AccountId
                              };
            return payTypes.ToList();
        }

        [HttpPost, Route("create")]
        public int addPayType(Entity.MstPayType payType)
        {
            try
            {

                db.Entry(payType).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return payType.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editPayType(Entity.MstPayType payType)
        {
            try
            {
                Entity.MstPayType update = db.MstPayType.Where(s => s.Id == payType.Id).FirstOrDefault<Entity.MstPayType>();

                if (update != null)
                {
                    update.PayType = payType.PayType;
                    update.AccountId = payType.AccountId;
                }

                db.Entry(update).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return "Success";
            }
            catch {
                return "Error";
            }
        }

        [HttpDelete, Route("delete")]
        public String deletePayType(Entity.MstPayType payType)
        {
            try
            {
                Entity.MstPayType delete = db.MstPayType.Where(s => s.Id == payType.Id).FirstOrDefault<Entity.MstPayType>();

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
