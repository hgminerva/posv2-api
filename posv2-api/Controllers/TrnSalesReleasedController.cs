using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/salesReleased")]
    public class TrnSalesReleasedController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnSalesReleased> listSalesReleaseds()
        {
            var salesReleaseds = from d in db.TrnSalesReleased
                                 select new Models.PosTrnSalesReleased
                              {
                                  Id = d.Id,
                                  SalesNumber = d.SalesNumber,
                                  ItemCode = d.ItemCode,
                                  ItemId = d.ItemId,
                                  Quantity = d.Quantity,
                                  EntryUserId = d.EntryUserId,
                                  EntryDateTime = d.EntryDateTime

                              };
            return salesReleaseds.ToList();
        }

        [HttpPost, Route("create")]
        public int addSalesReleased(Entity.TrnSalesReleased salesReleased)
        {
            try
            {

                db.Entry(salesReleased).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return salesReleased.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editSalesReleased(Entity.TrnSalesReleased salesReleased)
        {
            try
            {
                Entity.TrnSalesReleased update = db.TrnSalesReleased.Where(s => s.Id == salesReleased.Id).FirstOrDefault<Entity.TrnSalesReleased>();

                if (update != null)
                {
                    update.SalesNumber = salesReleased.SalesNumber;
                    update.ItemCode = salesReleased.ItemCode;
                    update.ItemId = salesReleased.ItemId;
                    update.Quantity = salesReleased.Quantity;
                    update.EntryUserId = salesReleased.EntryUserId;
                    update.EntryDateTime = salesReleased.EntryDateTime;
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
        public String deleteSalesReleased(Entity.TrnSalesReleased salesReleased)
        {
            try
            {
                Entity.TrnSalesReleased delete = db.TrnSalesReleased.Where(s => s.Id == salesReleased.Id).FirstOrDefault<Entity.TrnSalesReleased>();

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
