using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/itemPrice")]
    public class MstItemPriceController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstItemPrice> listItemPrices()
        {
            var prices = from d in db.MstItemPrice
                    select new Models.PosMstItemPrice
                    {
                        Id = d.Id,
                        ItemId = d.ItemId,
                        PriceDescription = d.PriceDescription,
                        Price = d.Price,
                        TriggerQuantity = d.TriggerQuantity,
                    };
            return prices.ToList();
        }


        [HttpPost, Route("create")]
        public int addItemPrice(Entity.MstItemPrice itemPrice)
        {
            try
            {

                db.Entry(itemPrice).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return itemPrice.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editItemPrice(Entity.MstItemPrice itemPrice)
        {
            try
            {
                Entity.MstItemPrice update = db.MstItemPrice.Where(s => s.Id == itemPrice.Id).FirstOrDefault<Entity.MstItemPrice>();

                if (update != null)
                {
                    update.ItemId = itemPrice.ItemId;
                    update.PriceDescription = itemPrice.PriceDescription;
                    update.Price = itemPrice.Price;
                    update.TriggerQuantity = itemPrice.TriggerQuantity;
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
        public String deleteItemPrice(Entity.MstItemPrice itemPrice)
        {
            try
            {
                Entity.MstItemPrice delete = db.MstItemPrice.Where(s => s.Id == itemPrice.Id).FirstOrDefault<Entity.MstItemPrice>();

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
