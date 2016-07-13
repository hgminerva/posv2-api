using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/debitCreditMemo")]
    public class TrnDebitCreditMemoController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnDebitCreditMemo> listDebitCreditMemos()
        {
            var debitCreditMemos = from d in db.TrnDebitCreditMemo
                         select new Models.PosTrnDebitCreditMemo
                              {
                                  Id = d.Id,
                                  PeriodId = d.PeriodId,
                                  DCMemoNumber = d.DCMemoNumber,
                                  DCMemoDate = d.DCMemoDate,
                                  Particulars = d.Particulars,
                                  PreparedBy = d.PreparedBy,
                                  CheckedBy = d.CheckedBy,
                                  ApprovedBy = d.ApprovedBy,
                                  IsLocked = d.IsLocked,
                                  EntryUserId = d.EntryUserId,
                                  EntryDateTime = d.EntryDateTime,
                                  UpdateUserId = d.UpdateUserId,
                                  UpdateDateTime = d.UpdateDateTime
                              };
            return debitCreditMemos.ToList();
        }

        [HttpPost, Route("create")]
        public int addDebitCreditMemo(Entity.TrnDebitCreditMemo debitCreditMemo)
        {
            try
            {

                db.Entry(debitCreditMemo).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return debitCreditMemo.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editDebitCreditMemo(Entity.TrnDebitCreditMemo debitCreditMemo)
        {
            try
            {
                Entity.TrnDebitCreditMemo update = db.TrnDebitCreditMemo.Where(s => s.Id == debitCreditMemo.Id).FirstOrDefault<Entity.TrnDebitCreditMemo>();

                if (update != null)
                {
                    update.PeriodId = debitCreditMemo.PeriodId;
                    update.DCMemoNumber = debitCreditMemo.DCMemoNumber;
                    update.DCMemoDate = debitCreditMemo.DCMemoDate;
                    update.Particulars = debitCreditMemo.Particulars;
                    update.PreparedBy = debitCreditMemo.PreparedBy;
                    update.CheckedBy = debitCreditMemo.CheckedBy;
                    update.ApprovedBy = debitCreditMemo.ApprovedBy;
                    update.IsLocked = debitCreditMemo.IsLocked;
                    update.EntryUserId = debitCreditMemo.EntryUserId;
                    update.EntryDateTime = debitCreditMemo.EntryDateTime;
                    update.UpdateUserId = debitCreditMemo.UpdateUserId;
                    update.UpdateDateTime = debitCreditMemo.UpdateDateTime;
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
        public String deleteDebitCreditMemo(Entity.TrnDebitCreditMemo debitCreditMemo)
        {
            try
            {
                Entity.TrnDebitCreditMemo delete = db.TrnDebitCreditMemo.Where(s => s.Id == debitCreditMemo.Id).FirstOrDefault<Entity.TrnDebitCreditMemo>();

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
