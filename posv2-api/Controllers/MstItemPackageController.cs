using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/itemPackage")]
    public class MstItemPackagesController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstItemPackage> listItemPackages()
        {
            var itemPackages = from d in db.MstItemPackage
                         select new Models.PosMstItemPackage
                              {
                                  Id = d.Id,
                                  ItemId = d.ItemId,
                                  PackageItemId = d.PackageItemId,
                                  UnitId = d.UnitId,
                                  Quantity = d.Quantity,
                                  IsOptional = d.IsOptional
                              };
            return itemPackages.ToList();
        }

        [HttpPost, Route("create")]
        public int addItemPackage(Entity.MstItemPackage itemPackage)
        {
            try
            {

                db.Entry(itemPackage).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return itemPackage.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editItemPackage(Entity.MstItemPackage itemPackage)
        {
            try
            {
                Entity.MstItemPackage update = db.MstItemPackage.Where(s => s.Id == itemPackage.Id).FirstOrDefault<Entity.MstItemPackage>();

                if (update != null)
                {
                    update.ItemId = itemPackage.ItemId;
                    update.PackageItemId = itemPackage.PackageItemId;
                    update.UnitId = itemPackage.UnitId;
                    update.Quantity = itemPackage.Quantity;
                    update.IsOptional = itemPackage.IsOptional;
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
        public String deleteItemPackage(Entity.MstItemPackage itemPackage)
        {
            try
            {
                Entity.MstItemPackage delete = db.MstItemPackage.Where(s => s.Id == itemPackage.Id).FirstOrDefault<Entity.MstItemPackage>();

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
