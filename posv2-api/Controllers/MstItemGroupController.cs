using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/itemGroup")]
    public class MstItemGroupController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstItemGroup> listItemGroups()
        {
            var itemGroups = from d in db.MstItemGroup
                              select new Models.PosMstItemGroup
                              {
                                  Id = d.Id,
                                  ItemGroup = d.ItemGroup,
                                  ImagePath = d.ImagePath,
                                  KitchenReport = d.KitchenReport,
                                  EntryUserId = d.EntryUserId,
                                  EntryDateTime = d.EntryDateTime,
                                  UpdateUserId = d.UpdateUserId,
                                  UpdateDateTime = d.UpdateDateTime,
                                  IsLocked = d.IsLocked
                              };
            return itemGroups.ToList();
        }

        [HttpPost, Route("create")]
        public int addItemGroup(Entity.MstItemGroup itemGroup)
        {
            try
            {

                db.Entry(itemGroup).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return itemGroup.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editItemGroup(Entity.MstItemGroup itemGroup)
        {
            try
            {
                Entity.MstItemGroup update = db.MstItemGroup.Where(s => s.Id == itemGroup.Id).FirstOrDefault<Entity.MstItemGroup>();

                if (update != null)
                {
                    update.ItemGroup = itemGroup.ItemGroup;
                    update.ImagePath = itemGroup.ImagePath;
                    update.KitchenReport = itemGroup.KitchenReport;
                    update.EntryUserId = itemGroup.EntryUserId;
                    update.EntryDateTime = itemGroup.EntryDateTime;
                    update.UpdateUserId = itemGroup.UpdateUserId;
                    update.UpdateDateTime = itemGroup.UpdateDateTime;
                    update.IsLocked = itemGroup.IsLocked;
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
        public String deleteItemGroup(Entity.MstItemGroup itemGroup)
        {
            try
            {
                Entity.MstItemGroup delete = db.MstItemGroup.Where(s => s.Id == itemGroup.Id).FirstOrDefault<Entity.MstItemGroup>();

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
