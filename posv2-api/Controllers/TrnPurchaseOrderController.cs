using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/purchaseOrder")]
    public class TrnPurchaseOrderController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnPurchaseOrder> listPurchaseOrders()
        {
            var purchaseOrders = from d in db.TrnPurchaseOrder
                        select new Models.PosTrnPurchaseOrder
                              {
                                  Id = d.Id,
                                  PeriodId = d.PeriodId,
                                  PurchaseOrderDate = d.PurchaseOrderDate,
                                  PurchaseOrderNumber = d.PurchaseOrderNumber,
                                  Amount = d.Amount,
                                  SupplierId = d.SupplierId,
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
            return purchaseOrders.ToList();
        }

        [HttpPost, Route("create")]
        public int addPurchaseOrder(Entity.TrnPurchaseOrder purchaseOrder)
        {
            try
            {

                db.Entry(purchaseOrder).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return purchaseOrder.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editPurchaseOrder(Entity.TrnPurchaseOrder purchaseOrder)
        {
            try
            {
                Entity.TrnPurchaseOrder update = db.TrnPurchaseOrder.Where(s => s.Id == purchaseOrder.Id).FirstOrDefault<Entity.TrnPurchaseOrder>();

                if (update != null)
                {
                    update.PeriodId = purchaseOrder.PeriodId;
                    update.PurchaseOrderDate = purchaseOrder.PurchaseOrderDate;
                    update.PurchaseOrderNumber = purchaseOrder.PurchaseOrderNumber;
                    update.Amount = purchaseOrder.Amount;
                    update.SupplierId = purchaseOrder.SupplierId;
                    update.Remarks = purchaseOrder.Remarks;
                    update.PreparedBy = purchaseOrder.PreparedBy;
                    update.CheckedBy = purchaseOrder.CheckedBy;
                    update.ApprovedBy = purchaseOrder.ApprovedBy;
                    update.IsLocked = purchaseOrder.IsLocked;
                    update.EntryUserId = purchaseOrder.EntryUserId;
                    update.EntryDateTime = purchaseOrder.EntryDateTime;
                    update.UpdateUserId = purchaseOrder.UpdateUserId;
                    update.UpdateDateTime = purchaseOrder.UpdateDateTime;
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
        public String deletePurchaseOrder(Entity.TrnPurchaseOrder purchaseOrder)
        {
            try
            {
                Entity.TrnPurchaseOrder delete = db.TrnPurchaseOrder.Where(s => s.Id == purchaseOrder.Id).FirstOrDefault<Entity.TrnPurchaseOrder>();

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
