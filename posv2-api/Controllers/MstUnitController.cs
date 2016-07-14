using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/unit")]
    public class MstUnitController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstUnit> listUnits()
        {
            var units = from d in db.MstUnit
                         select new Models.PosMstUnit
                              {
                                  Id = d.Id,
                                  Unit = d.Unit
                              };
            return units.ToList();
        }

        [HttpPost, Route("create")]
        public int addUnit(Entity.MstUnit unit)
        {
            try
            {

                db.Entry(unit).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return unit.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editUnit(Entity.MstUnit unit)
        {
            try
            {
                Entity.MstUnit update = db.MstUnit.Where(s => s.Id == unit.Id).FirstOrDefault<Entity.MstUnit>();

                if (update != null)
                {
                    update.Unit = unit.Unit;
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
        public String deleteUnit(Entity.MstUnit unit)
        {
            try
            {
                Entity.MstUnit delete = db.MstUnit.Where(s => s.Id == unit.Id).FirstOrDefault<Entity.MstUnit>();

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
