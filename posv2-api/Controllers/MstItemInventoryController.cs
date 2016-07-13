using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/itemInventorie")]
    public class MstItemInventoryController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstItemInventory> listItemInventories()
        {
            var itemInventories = from d in db.MstItemInventory
                              select new Models.PosMstItemInventory
                              {
                                  Id = d.Id,
                                  ItemId = d.ItemId,
                                  InventoryDate = d.InventoryDate,
                                  Quantity = d.Quantity
                              };
            return itemInventories.ToList();
        }


        [HttpPost, Route("create")]
        public int addItemInventory(Entity.MstItemInventory itemInventory)
        {
            try
            {

                db.Entry(itemInventory).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return itemInventory.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editItemInventory(Entity.MstItemInventory itemInventory)
        {
            try
            {
                Entity.MstItemInventory update = db.MstItemInventory.Where(s => s.Id == itemInventory.Id).FirstOrDefault<Entity.MstItemInventory>();

                if (update != null)
                {
                    update.ItemId = itemInventory.ItemId;
                    update.InventoryDate = itemInventory.InventoryDate;
                    update.Quantity = itemInventory.Quantity;
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
        public String deleteItemInventory(Entity.MstItemInventory itemInventory)
        {
            try
            {
                Entity.MstItemInventory delete = db.MstItemInventory.Where(s => s.Id == itemInventory.Id).FirstOrDefault<Entity.MstItemInventory>();

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
