using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/journal")]
    public class TrnJournalController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnJournal> listJournals()
        {
            var journals = from d in db.TrnJournal
                        select new Models.PosTrnJournal
                              {
                                  Id = d.Id,
                                  JournalDate = d.JournalDate,
                                  JournalRefDocument = d.JournalRefDocument,
                                  AccountId = d.AccountId,
                                  DebitAmount = d.DebitAmount,
                                  CreditAmount = d.CreditAmount,
                                  SalesId = d.SalesId,
                                  StockInId = d.StockInId,
                                  StockOutId = d.StockOutId,
                                  CollectionId = d.CollectionId,
                                  DCMemoId = d.DCMemoId,
                                  DisbursementId = d.DisbursementId
                              };
            return journals.ToList();
        }

        [HttpPost, Route("create")]
        public int addJournal(Entity.TrnJournal journal)
        {
            try
            {

                db.Entry(journal).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return journal.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editJournal(Entity.TrnJournal journal)
        {
            try
            {
                Entity.TrnJournal update = db.TrnJournal.Where(s => s.Id == journal.Id).FirstOrDefault<Entity.TrnJournal>();

                if (update != null)
                {
                    update.JournalDate = journal.JournalDate;
                    update.JournalRefDocument = journal.JournalRefDocument;
                    update.AccountId = journal.AccountId;
                    update.DebitAmount = journal.DebitAmount;
                    update.CreditAmount = journal.CreditAmount;
                    update.SalesId = journal.SalesId;
                    update.StockInId = journal.StockInId;
                    update.StockOutId = journal.StockOutId;
                    update.CollectionId = journal.CollectionId;
                    update.DCMemoId = journal.DCMemoId;
                    update.DisbursementId = journal.DisbursementId;
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

        [HttpPost, Route("remove")]
        public String deleteJournal(Entity.TrnJournal journal)
        {
            try
            {
                Entity.TrnJournal delete = db.TrnJournal.Where(s => s.Id == journal.Id).FirstOrDefault<Entity.TrnJournal>();

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
