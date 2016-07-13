using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/stockOut")]
    public class TrnStockOutController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnStockOut> listStockOuts()
        {
            var stockOuts = from d in db.TrnStockOut
                            select new Models.PosTrnStockOut
                              {
                                  Id = d.Id,
                                  PeriodId = d.PeriodId,
                                  StockOutDate = d.StockOutDate,
                                  StockOutNumber = d.StockOutNumber,
                                  AccountId = d.AccountId,
                                  Remarks = d.Remarks,
                                  PreparedBy = d.PreparedBy,
                                  CheckedBy = d.CheckedBy,
                                  ApprovedBy = d.ApprovedBy,
                                  IsLocked = d.IsLocked,
                                  EntryDateTime = d.EntryDateTime,
                                  EntryUserId = d.EntryUserId,
                                  UpdateUserId = d.UpdateUserId,
                                  UpdateDateTime = d.UpdateDateTime
                              };
            return stockOuts.ToList();
        }

        [HttpPost, Route("create")]
        public int addStockOut(Entity.TrnStockOut stockOut)
        {
            try
            {

                db.Entry(stockOut).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return stockOut.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editStockOut(Entity.TrnStockOut stockOut)
        {
            try
            {
                Entity.TrnStockOut update = db.TrnStockOut.Where(s => s.Id == stockOut.Id).FirstOrDefault<Entity.TrnStockOut>();

                if (update != null)
                {
                    update.PeriodId = stockOut.PeriodId;
                    update.StockOutDate = stockOut.StockOutDate;
                    update.StockOutNumber = stockOut.StockOutNumber;
                    update.AccountId = stockOut.AccountId;
                    update.Remarks = stockOut.Remarks;
                    update.PreparedBy = stockOut.PreparedBy;
                    update.CheckedBy = stockOut.CheckedBy;
                    update.ApprovedBy = stockOut.ApprovedBy;
                    update.IsLocked = stockOut.IsLocked;
                    update.EntryDateTime = stockOut.EntryDateTime;
                    update.EntryUserId = stockOut.EntryUserId;
                    update.UpdateUserId = stockOut.UpdateUserId;
                    update.UpdateDateTime = stockOut.UpdateDateTime;
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
        public String deleteStockOut(Entity.TrnStockOut stockOut)
        {
            try
            {
                Entity.TrnStockOut delete = db.TrnStockOut.Where(s => s.Id == stockOut.Id).FirstOrDefault<Entity.TrnStockOut>();

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