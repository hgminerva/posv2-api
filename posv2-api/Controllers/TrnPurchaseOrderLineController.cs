using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/purchaseOrderLine")]
    public class TrnPurchaseOrderLineController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnPurchaseOrderLine> listPurchaseOrderLines()
        {
            var purchaseOrderLines = from d in db.TrnPurchaseOrderLine
                        select new Models.PosTrnPurchaseOrderLine
                              {
                                  Id = d.Id,
                                  PurchaseOrderId = d.PurchaseOrderId,
                                  ItemId = d.ItemId,
                                  UnitId = d.UnitId,
                                  Quantity = d.Quantity,
                                  Cost = d.Cost,
                                  Amount = d.Amount
                              };
            return purchaseOrderLines.ToList();
        }

        [HttpPost, Route("create")]
        public int addPurchaseOrderLine(Entity.TrnPurchaseOrderLine purchaseOrderLine)
        {
            try
            {

                db.Entry(purchaseOrderLine).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return purchaseOrderLine.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editPurchaseOrderLine(Entity.TrnPurchaseOrderLine purchaseOrderLine)
        {
            try
            {
                Entity.TrnPurchaseOrderLine update = db.TrnPurchaseOrderLine.Where(s => s.Id == purchaseOrderLine.Id).FirstOrDefault<Entity.TrnPurchaseOrderLine>();

                if (update != null)
                {
                    update.PurchaseOrderId = purchaseOrderLine.PurchaseOrderId;
                    update.ItemId = purchaseOrderLine.ItemId;
                    update.UnitId = purchaseOrderLine.UnitId;
                    update.Quantity = purchaseOrderLine.Quantity;
                    update.Cost = purchaseOrderLine.Cost;
                    update.Amount = purchaseOrderLine.Amount;
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
        public String deletePurchaseOrderLine(Entity.TrnPurchaseOrderLine purchaseOrderLine)
        {
            try
            {
                Entity.TrnPurchaseOrderLine delete = db.TrnPurchaseOrderLine.Where(s => s.Id == purchaseOrderLine.Id).FirstOrDefault<Entity.TrnPurchaseOrderLine>();

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
