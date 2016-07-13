using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/itemComponent")]
    public class MstItemComponentController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstItemComponent> listItemComponents()
        {
            var itemComponents = from d in db.MstItemComponent
                         select new Models.PosMstItemComponent
                              {
                                  Id = d.Id,
                                  ItemId = d.ItemId,
                                  ComponentItemId = d.ComponentItemId,
                                  UnitId = d.UnitId,
                                  Quantity = d.Quantity,
                                  Cost = d.Cost,
                                  Amount = d.Amount,
                                  IsPrinted = d.IsPrinted
                              };
            return itemComponents.ToList();
        }

        [HttpPost, Route("create")]
        public int addItemComponent(Entity.MstItemComponent itemComponent)
        {
            try
            {

                db.Entry(itemComponent).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return itemComponent.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editItemComponent(Entity.MstItemComponent itemComponent)
        {
            try
            {
                Entity.MstItemComponent update = db.MstItemComponent.Where(s => s.Id == itemComponent.Id).FirstOrDefault<Entity.MstItemComponent>();

                if (update != null)
                {
                    update.ItemId = itemComponent.ItemId;
                    update.ComponentItemId = itemComponent.ComponentItemId;
                    update.UnitId = itemComponent.UnitId;
                    update.Quantity = itemComponent.Quantity;
                    update.Cost = itemComponent.Cost;
                    update.Amount = itemComponent.Amount;
                    update.IsPrinted = itemComponent.IsPrinted;
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
        public String deleteItemComponent(Entity.MstItemComponent itemComponent)
        {
            try
            {
                Entity.MstItemComponent delete = db.MstItemComponent.Where(s => s.Id == itemComponent.Id).FirstOrDefault<Entity.MstItemComponent>();

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
