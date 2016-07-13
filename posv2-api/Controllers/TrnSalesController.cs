using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/sales")]
    public class TrnSalesController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnSales> listSales()
        {
            var sales = from d in db.TrnSales
                    select new Models.PosTrnSales
                    {
                        Id = d.Id,
                        PeriodId = d.PeriodId,
                        SalesDate = d.SalesDate, 
                        SalesNumber = d.SalesNumber, 
                        ManualInvoiceNumber = d.ManualInvoiceNumber,
                        Amount = d.Amount, 
                        TableId = d.TableId, 
                        CustomerId = d.CustomerId, 
                        AccountId = d.AccountId,
                        TermId = d.TermId,
                        DiscountId = d.DiscountId,
                        SeniorCitizenId = d.SeniorCitizenId,
                        SeniorCitizenName = d.SeniorCitizenName,
                        SeniorCitizenAge = d.SeniorCitizenAge,
                        Remarks = d.Remarks,
                        SalesAgent = d.SalesAgent,
                        TerminalId = d.TerminalId,
                        PreparedBy = d.PreparedBy,
                        CheckedBy = d.CheckedBy,
                        ApprovedBy = d.ApprovedBy,
                        IsLocked = d.IsLocked,
                        IsCancelled = d.IsCancelled,
                        PaidAmount = d.PaidAmount,
                        CreditAmount = d.CreditAmount,
                        DebitAmount = d.DebitAmount,
                        BalanceAmount = d.BalanceAmount,
                        EntryUserId = d.EntryUserId,
                        EntryDateTime = d.EntryDateTime,
                        UpdateUserId = d.UpdateUserId,
                        UpdateDateTime = d.UpdateDateTime,
                        Pax = d.Pax
                    };
            return sales.ToList();
        }

        [HttpPost, Route("create")]
        public int addSales(Entity.TrnSales sales)
        {
            try
            {

                db.Entry(sales).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return sales.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editSales(Entity.TrnSales sales)
        {
            try
            {
                Entity.TrnSales update = db.TrnSales.Where(s => s.Id == sales.Id).FirstOrDefault<Entity.TrnSales>();

                if (update != null)
                {

                    update.PeriodId = sales.PeriodId;
                    update.SalesDate = sales.SalesDate;
                    update.SalesNumber = sales.SalesNumber;
                    update.ManualInvoiceNumber = sales.ManualInvoiceNumber;
                    update.Amount = sales.Amount;
                    update.TableId = sales.TableId;
                    update.CustomerId = sales.CustomerId;
                    update.AccountId = sales.AccountId;
                    update.TermId = sales.TermId;
                    update.DiscountId = sales.DiscountId;
                    update.SeniorCitizenId = sales.SeniorCitizenId;
                    update.SeniorCitizenName = sales.SeniorCitizenName;
                    update.SeniorCitizenAge = sales.SeniorCitizenAge;
                    update.Remarks = sales.Remarks;
                    update.SalesAgent = sales.SalesAgent;
                    update.TerminalId = sales.TerminalId;
                    update.PreparedBy = sales.PreparedBy;
                    update.CheckedBy = sales.CheckedBy;
                    update.ApprovedBy = sales.ApprovedBy;
                    update.IsLocked = sales.IsLocked;
                    update.IsCancelled = sales.IsCancelled;
                    update.PaidAmount = sales.PaidAmount;
                    update.CreditAmount = sales.CreditAmount;
                    update.DebitAmount = sales.DebitAmount;
                    update.BalanceAmount = sales.BalanceAmount;
                    update.EntryUserId = sales.EntryUserId;
                    update.EntryDateTime = sales.EntryDateTime;
                    update.UpdateUserId = sales.UpdateUserId;
                    update.UpdateDateTime = sales.UpdateDateTime;
                    update.Pax = sales.Pax;

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
        public String deleteSales(Entity.MstPayType sales)
        {
            try
            {
                Entity.TrnSales delete = db.TrnSales.Where(s => s.Id == sales.Id).FirstOrDefault<Entity.TrnSales>();

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
