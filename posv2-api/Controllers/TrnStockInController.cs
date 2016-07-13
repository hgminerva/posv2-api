using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/stockIn")]
    public class TrnStockInController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnStockIn> listStockIns()
        {
            var stockIns = from d in db.TrnStockIn
                        select new Models.PosTrnStockIn
                        {
                            Id = d.Id,
                            PeriodId = d.PeriodId,
                            StockInDate = d.StockInDate,
                            StockInNumber = d.StockInNumber,
                            SupplierId = d.SupplierId,
                            Remarks = d.Remarks,
                            IsReturn = d.IsReturn,
                            CollectionId = d.CollectionId,
                            PurchaseOrderId = d.PurchaseOrderId,
                            PreparedBy = d.PreparedBy,
                            CheckedBy = d.CheckedBy,
                            ApprovedBy = d.ApprovedBy,
                            IsLocked = d.IsLocked,
                            EntryUserId = d.EntryUserId,
                            EntryDateTime = d.EntryDateTime,
                            UpdateUserId = d.UpdateUserId,
                            UpdateDateTime = d.UpdateDateTime
                        };
            return stockIns.ToList();
        }

        [HttpPost, Route("create")]
        public int addStockIn(Entity.TrnStockIn stockIn)
        {
            try
            {

                db.Entry(stockIn).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return stockIn.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editStockIn(Entity.TrnStockIn stockIn)
        {
            try
            {
                Entity.TrnStockIn update = db.TrnStockIn.Where(s => s.Id == stockIn.Id).FirstOrDefault<Entity.TrnStockIn>();

                if (update != null)
                {
                    update.PeriodId = stockIn.PeriodId;
                    update.StockInDate = stockIn.StockInDate;
                    update.StockInNumber = stockIn.StockInNumber;
                    update.SupplierId = stockIn.SupplierId;
                    update.Remarks = stockIn.Remarks;
                    update.IsReturn = stockIn.IsReturn;
                    update.CollectionId = stockIn.CollectionId;
                    update.PurchaseOrderId = stockIn.PurchaseOrderId;
                    update.PreparedBy = stockIn.PreparedBy;
                    update.CheckedBy = stockIn.CheckedBy;
                    update.ApprovedBy = stockIn.ApprovedBy;
                    update.IsLocked = stockIn.IsLocked;
                    update.EntryUserId = stockIn.EntryUserId;
                    update.EntryDateTime = stockIn.EntryDateTime;
                    update.UpdateUserId = stockIn.UpdateUserId;
                    update.UpdateDateTime = stockIn.UpdateDateTime;
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
        public String deleteStockIn(Entity.TrnStockIn stockIn)
        {
            try
            {
                Entity.TrnStockIn delete = db.TrnStockIn.Where(s => s.Id == stockIn.Id).FirstOrDefault<Entity.TrnStockIn>();

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
