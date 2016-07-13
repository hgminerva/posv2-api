using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/tax")]
    public class MstTaxController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstTax> listTaxes()
        {
            var taxes = from d in db.MstTax
                         select new Models.PosMstTax
                              {
                                  Id = d.Id,
                                  Code = d.Code,
                                  Tax = d.Tax,
                                  Rate = d.Rate,
                                  AccountId = d.AccountId
                              };
            return taxes.ToList();
        }

        [HttpPost, Route("create")]
        public int addTax(Entity.MstTax tax)
        {
            try
            {

                db.Entry(tax).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return tax.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editTax(Entity.MstTax tax)
        {
            try
            {
                Entity.MstTax update = db.MstTax.Where(s => s.Id == tax.Id).FirstOrDefault<Entity.MstTax>();

                if (update != null)
                {
                    update.Code = tax.Code;
                    update.Tax = tax.Tax;
                    update.Rate = tax.Rate;
                    update.AccountId = tax.AccountId;
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
        public String deleteTax(Entity.MstTax tax)
        {
            try
            {
                Entity.MstTax delete = db.MstTax.Where(s => s.Id == tax.Id).FirstOrDefault<Entity.MstTax>();

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
