using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/discountItem")]
    public class MstDiscountItemsController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstDiscountItem> listDiscountItems()
        {
            var discountItems = from d in db.MstDiscountItem
                         select new Models.PosMstDiscountItem
                              {
                                  Id = d.Id,
                                  DiscountId = d.DiscountId,
                                  ItemId = d.ItemId
                              };
            return discountItems.ToList();
        }

        [HttpPost, Route("create")]
        public int addDiscountItem(Entity.MstDiscountItem discountItems)
        {
            try
            {

                db.Entry(discountItems).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return discountItems.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editDiscountItem(Entity.MstDiscountItem discountItems)
        {
            try
            {
                Entity.MstDiscountItem update = db.MstDiscountItem.Where(s => s.Id == discountItems.Id).FirstOrDefault<Entity.MstDiscountItem>();

                if (update != null)
                {
                    update.DiscountId = discountItems.DiscountId;
                    update.ItemId = discountItems.ItemId;
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
        public String deleteDiscountItem(Entity.MstDiscountItem discountItems)
        {
            try
            {
                Entity.MstDiscountItem delete = db.MstDiscountItem.Where(s => s.Id == discountItems.Id).FirstOrDefault<Entity.MstDiscountItem>();

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
