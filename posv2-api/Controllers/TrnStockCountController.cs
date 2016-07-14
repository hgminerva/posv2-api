using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/stockCount")]
    public class TrnStockCountController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnStockCount> listStockCounts()
        {
            var stockCounts = from d in db.TrnStockCount
                              select new Models.PosTrnStockCount
                              {
                                  Id = d.Id,
                                  PeriodId = d.PeriodId,
                                  StockCountDate = d.StockCountDate,
                                  StockCountNumber = d.StockCountNumber,
                                  Remarks = d.Remarks,
                                  PreparedBy = d.PreparedBy,
                                  CheckedBy = d.CheckedBy,
                                  ApprovedBy = d.ApprovedBy,
                                  IsLocked = d.IsLocked,
                                  EntryUserId = d.EntryUserId,
                                  EntryDateTime = d.EntryDateTime,
                                  UpdateUserId = d.UpdateUserId,
                                  UpdateDateTime = d.UpdateDateTime
                              };
            return stockCounts.ToList();
        }

        [HttpPost, Route("create")]
        public int addStockCount(Entity.TrnStockCount stockCount)
        {
            try
            {

                db.Entry(stockCount).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return stockCount.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editStockCount(Entity.TrnStockCount stockCount)
        {
            try
            {
                Entity.TrnStockCount update = db.TrnStockCount.Where(s => s.Id == stockCount.Id).FirstOrDefault<Entity.TrnStockCount>();

                if (update != null)
                {
                    update.PeriodId = stockCount.PeriodId;
                    update.StockCountDate = stockCount.StockCountDate;
                    update.StockCountNumber = stockCount.StockCountNumber;
                    update.Remarks = stockCount.Remarks;
                    update.PreparedBy = stockCount.PreparedBy;
                    update.CheckedBy = stockCount.CheckedBy;
                    update.ApprovedBy = stockCount.ApprovedBy;
                    update.IsLocked = stockCount.IsLocked;
                    update.EntryUserId = stockCount.EntryUserId;
                    update.EntryDateTime = stockCount.EntryDateTime;
                    update.UpdateUserId = stockCount.UpdateUserId;
                    update.UpdateDateTime = stockCount.UpdateDateTime;
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
        public String deleteStockCount(Entity.TrnStockCount stockCount)
        {
            try
            {
                Entity.TrnStockCount delete = db.TrnStockCount.Where(s => s.Id == stockCount.Id).FirstOrDefault<Entity.TrnStockCount>();

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
