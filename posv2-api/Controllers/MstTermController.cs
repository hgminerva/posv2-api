using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/term")]
    public class MstTermController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstTerm> listTerm()
        {
            var terms = from d in db.MstTerm
                         select new Models.PosMstTerm
                              {
                                  Id = d.Id,
                                  Term = d.Term,
                                  NumberOfDays = d.NumberOfDays
                              };
            return terms.ToList();
        }

        [HttpPost, Route("create")]
        public int addTerm(Entity.MstTerm term)
        {
            try
            {

                db.Entry(term).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return term.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editTerm(Entity.MstTerm term)
        {
            try
            {
                Entity.MstTerm update = db.MstTerm.Where(s => s.Id == term.Id).FirstOrDefault<Entity.MstTerm>();

                if (update != null)
                {
                    update.Term = term.Term;
                    update.NumberOfDays = update.NumberOfDays;
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
        public String deleteTerm(Entity.MstTerm term)
        {
            try
            {
                Entity.MstTerm delete = db.MstTerm.Where(s => s.Id == term.Id).FirstOrDefault<Entity.MstTerm>();

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
