using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/debitCreditMemoLine")]
    public class TrnDebitCreditMemoLineController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnDebitCreditMemoLine> listDebitCreditMemoLines()
        {
            var debitCreditMemoLines = from d in db.TrnDebitCreditMemoLine
                         select new Models.PosTrnDebitCreditMemoLine
                              {
                                  Id = d.Id,
                                  DCMemoId = d.DCMemoId,
                                  SalesId = d.SalesId,
                                  AccountId = d.AccountId,
                                  Particulars = d.Particulars,
                                  DebitAmount = d.DebitAmount,
                                  CreditAmount = d.CreditAmount
                              };
            return debitCreditMemoLines.ToList();
        }

        [HttpPost, Route("create")]
        public int addDebitCreditMemoLine(Entity.TrnDebitCreditMemoLine debitCreditMemoLine)
        {
            try
            {

                db.Entry(debitCreditMemoLine).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return debitCreditMemoLine.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editDebitCreditMemoLine(Entity.TrnDebitCreditMemoLine debitCreditMemoLine)
        {
            try
            {
                Entity.TrnDebitCreditMemoLine update = db.TrnDebitCreditMemoLine.Where(s => s.Id == debitCreditMemoLine.Id).FirstOrDefault<Entity.TrnDebitCreditMemoLine>();

                if (update != null)
                {
                    update.DCMemoId = debitCreditMemoLine.DCMemoId;
                    update.SalesId = debitCreditMemoLine.SalesId;
                    update.AccountId = debitCreditMemoLine.AccountId;
                    update.Particulars = debitCreditMemoLine.Particulars;
                    update.DebitAmount = debitCreditMemoLine.DebitAmount;
                    update.CreditAmount = debitCreditMemoLine.CreditAmount;
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
        public String deleteDebitCreditMemoLine(Entity.TrnDebitCreditMemoLine debitCreditMemoLine)
        {
            try
            {
                Entity.TrnDebitCreditMemoLine delete = db.TrnDebitCreditMemoLine.Where(s => s.Id == debitCreditMemoLine.Id).FirstOrDefault<Entity.TrnDebitCreditMemoLine>();

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
