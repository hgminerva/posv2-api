using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/period")]
    public class MstPeriodController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstPeriod> listPeriods()
        {
            var periods = from d in db.MstPeriod
                        select new Models.PosMstPeriod
                        {
                            Id = d.Id,
                            Period = d.Period
                        };
            return periods.ToList();
        }

        [HttpPost, Route("create")]
        public int addPeriod(Entity.MstPeriod period)
        {
            try
            {

                db.Entry(period).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return period.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editPeriod(Entity.MstPeriod period)
        {
            try
            {
                Entity.MstPeriod update = db.MstPeriod.Where(s => s.Id == period.Id).FirstOrDefault<Entity.MstPeriod>();

                if (update != null)
                {
                    update.Period = period.Period;
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
        public String deletePeriod(Entity.MstPeriod period)
        {
            try
            {
                Entity.MstPeriod delete = db.MstPeriod.Where(s => s.Id == period.Id).FirstOrDefault<Entity.MstPeriod>();

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
