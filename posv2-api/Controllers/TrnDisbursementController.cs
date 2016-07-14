using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/disbursement")]
    public class TrnDisbursementController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnDisbursement> listDisbursements()
        {
            var disbursements = from d in db.TrnDisbursement
                            select new Models.PosTrnDisbursement
                            {
                                Id = d.Id,
                                PeriodId = d.PeriodId,
                                DisbursementDate = d.DisbursementDate,
                                DisbursementNumber = d.DisbursementNumber,
                                DisbursementType = d.DisbursementType,
                                AccountId = d.AccountId,
                                Amount = d.Amount,
                                PayTypeId = d.PayTypeId,
                                TerminalId = d.TerminalId,
                                Remarks = d.Remarks,
                                IsReturn = d.IsReturn,
                                StockInId = d.StockInId,
                                PreparedBy = d.PreparedBy,
                                CheckedBy = d.CheckedBy,
                                ApprovedBy = d.ApprovedBy,
                                IsLocked = d.IsLocked,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = d.EntryDateTime,
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = d.UpdateDateTime,
                                Amount1000 = d.Amount1000,
                                Amount500 = d.Amount500,
                                Amount200 = d.Amount200,
                                Amount100 = d.Amount100,
                                Amount50 = d.Amount50,
                                Amount20 = d.Amount20,
                                Amount10 = d.Amount10,
                                Amount5 = d.Amount5,
                                Amount1 = d.Amount1,
                                Amount025 = d.Amount025,
                                Amount010 = d.Amount010,
                                Amount005 = d.Amount005,
                                Amount001 = d.Amount001,
                                Payee = d.Payee
                            };
            return disbursements.ToList();
        }

        [HttpPost, Route("create")]
        public int addDisbursement(Entity.TrnDisbursement disbursement)
        {
            try
            {

                db.Entry(disbursement).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return disbursement.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editDisbursement(Entity.TrnDisbursement disbursement)
        {
            try
            {
                Entity.TrnDisbursement update = db.TrnDisbursement.Where(s => s.Id == disbursement.Id).FirstOrDefault<Entity.TrnDisbursement>();

                if (update != null)
                {
                    update.PeriodId = disbursement.PeriodId;
                    update.DisbursementDate = disbursement.DisbursementDate;
                    update.DisbursementNumber = disbursement.DisbursementNumber;
                    update.DisbursementType = disbursement.DisbursementType;
                    update.AccountId = disbursement.AccountId;
                    update.Amount = disbursement.Amount;
                    update.PayTypeId = disbursement.PayTypeId;
                    update.TerminalId = disbursement.TerminalId;
                    update.Remarks = disbursement.Remarks;
                    update.IsReturn = disbursement.IsReturn;
                    update.StockInId = disbursement.StockInId;
                    update.PreparedBy = disbursement.PreparedBy;
                    update.CheckedBy = disbursement.CheckedBy;
                    update.ApprovedBy = disbursement.ApprovedBy;
                    update.IsLocked = disbursement.IsLocked;
                    update.EntryUserId = disbursement.EntryUserId;
                    update.EntryDateTime = disbursement.EntryDateTime;
                    update.UpdateUserId = disbursement.UpdateUserId;
                    update.UpdateDateTime = disbursement.UpdateDateTime;
                    update.Amount1000 = disbursement.Amount1000;
                    update.Amount500 = disbursement.Amount500;
                    update.Amount200 = disbursement.Amount200;
                    update.Amount100 = disbursement.Amount100;
                    update.Amount50 = disbursement.Amount50;
                    update.Amount20 = disbursement.Amount20;
                    update.Amount10 = disbursement.Amount10;
                    update.Amount5 = disbursement.Amount5;
                    update.Amount1 = disbursement.Amount1;
                    update.Amount025 = disbursement.Amount025;
                    update.Amount010 = disbursement.Amount010;
                    update.Amount005 = disbursement.Amount005;
                    update.Amount001 = disbursement.Amount001;
                    update.Payee = disbursement.Payee;
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
        public String deleteDisbursement(Entity.MstPayType disbursement)
        {
            try
            {
                Entity.TrnDisbursement delete = db.TrnDisbursement.Where(s => s.Id == disbursement.Id).FirstOrDefault<Entity.TrnDisbursement>();

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
