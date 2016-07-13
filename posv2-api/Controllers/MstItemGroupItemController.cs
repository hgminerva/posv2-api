using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/itemGroup")]
    public class MstItemGroupItemController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstItemGroupItem> listItemGroupItems()
        {
            var itemGroupItems = from d in db.MstItemGroupItem
                              select new Models.PosMstItemGroupItem
                              {
                                  Id = d.Id,
                                  ItemId = d.ItemId,
                                  ItemGroupId = d.ItemGroupId
                              };
            return itemGroupItems.ToList();
        }

        [HttpPost, Route("create")]
        public int addItemGroupItem(Entity.MstItemGroupItem itemGroupItem)
        {
            try
            {

                db.Entry(itemGroupItem).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return itemGroupItem.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editItemGroupItem(Entity.MstItemGroupItem itemGroupItem)
        {
            try
            {
                Entity.MstItemGroupItem update = db.MstItemGroupItem.Where(s => s.Id == itemGroupItem.Id).FirstOrDefault<Entity.MstItemGroupItem>();

                if (update != null)
                {
                    update.ItemId = itemGroupItem.ItemId;
                    update.ItemGroupId = itemGroupItem.ItemGroupId;
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

        [HttpPost, Route("delete")]
        public String deleteItemGroupItem(Entity.MstItemGroupItem itemGroupItem)
        {
            try
            {
                Entity.MstItemGroupItem delete = db.MstItemGroupItem.Where(s => s.Id == itemGroupItem.Id).FirstOrDefault<Entity.MstItemGroupItem>();

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
