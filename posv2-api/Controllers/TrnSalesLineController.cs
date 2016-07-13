using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/salesLine")]
    public class TrnSalesLineController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnSalesLine> listSalesLines()
        {
            var salesLines = from d in db.TrnSalesLine
                        select new Models.PosTrnSalesLine
                        {
                            Id = d.Id,
                            SalesId = d.SalesId,
                            ItemId = d.ItemId,
                            UnitId = d.UnitId,
                            Price = d.Price,
                            DiscountId = d.DiscountId,
                            DiscountRate = d.DiscountRate,
                            DiscountAmount = d.DiscountAmount,
                            NetPrice = d.NetPrice,
                            Quantity = d.Quantity,
                            Amount = d.Amount,
                            TaxId = d.TaxId,
                            TaxRate = d.TaxRate,
                            TaxAmount = d.TaxAmount,
                            SalesAccountId = d.SalesAccountId,
                            AssetAccountId = d.AssetAccountId,
                            CostAccountId = d.CostAccountId,
                            TaxAccountId = d.TaxAccountId,
                            SalesLineTimeStamp = d.SalesLineTimeStamp,
                            UserId = d.UserId,
                            Preparation = d.Preparation
                        };
            return salesLines.ToList();
        }

        [HttpPost, Route("create")]
        public int addSalesLine(Entity.TrnSalesLine salesLine)
        {
            try
            {

                db.Entry(salesLine).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return salesLine.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editSalesLine(Entity.TrnSalesLine salesLine)
        {
            try
            {
                Entity.TrnSalesLine update = db.TrnSalesLine.Where(s => s.Id == salesLine.Id).FirstOrDefault<Entity.TrnSalesLine>();

                if (update != null)
                {

                    update.SalesId = salesLine.SalesId;
                    update.ItemId = salesLine.ItemId;
                    update.UnitId = salesLine.UnitId;
                    update.Price = salesLine.Price;
                    update.DiscountId = salesLine.DiscountId;
                    update.DiscountRate = salesLine.DiscountRate;
                    update.DiscountAmount = salesLine.DiscountAmount;
                    update.NetPrice = salesLine.NetPrice;
                    update.Quantity = salesLine.Quantity;
                    update.Amount = salesLine.Amount;
                    update.TaxId = salesLine.TaxId;
                    update.TaxRate = salesLine.TaxRate;
                    update.TaxAmount = salesLine.TaxAmount;
                    update.SalesAccountId = salesLine.SalesAccountId;
                    update.AssetAccountId = salesLine.AssetAccountId;
                    update.CostAccountId = salesLine.CostAccountId;
                    update.TaxAccountId = salesLine.TaxAccountId;
                    update.SalesLineTimeStamp = salesLine.SalesLineTimeStamp;
                    update.UserId = salesLine.UserId;
                    update.Preparation = salesLine.Preparation;
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
        public String deleteSalesLine(Entity.TrnSalesLine salesLine)
        {
            try
            {
                Entity.TrnSalesLine delete = db.TrnSalesLine.Where(s => s.Id == salesLine.Id).FirstOrDefault<Entity.TrnSalesLine>();

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
