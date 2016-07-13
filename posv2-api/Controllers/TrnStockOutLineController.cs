using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/stockOutLine")]
    public class TrnStockOutLineController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnStockOutLine> listStockOutLines()
        {
            var stockOutLines = from d in db.TrnStockOutLine
                                select new Models.PosTrnStockOutLine
                              {
                                  Id = d.Id,
                                  StockOutId = d.StockOutId,
                                  ItemId  = d.ItemId,
                                  UnitId = d.UnitId,
                                  Quantity = d.Quantity,
                                  Cost = d.Cost,
                                  Amount = d.Amount,
                                  AssetAccountId = d.AssetAccountId
                              };
            return stockOutLines.ToList();
        }

        [HttpPost, Route("create")]
        public int addStockOutLine(Entity.TrnStockOutLine stockOutLine)
        {
            try
            {

                db.Entry(stockOutLine).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return stockOutLine.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editStockOutLine(Entity.TrnStockOutLine stockOutLine)
        {
            try
            {
                Entity.TrnStockOutLine update = db.TrnStockOutLine.Where(s => s.Id == stockOutLine.Id).FirstOrDefault<Entity.TrnStockOutLine>();

                if (update != null)
                {
                    update.StockOutId = stockOutLine.StockOutId;
                    update.ItemId  = stockOutLine.ItemId;
                    update.UnitId = stockOutLine.UnitId;
                    update.Quantity = stockOutLine.Quantity;
                    update.Cost = stockOutLine.Cost;
                    update.Amount = stockOutLine.Amount;
                    update.AssetAccountId = stockOutLine.AssetAccountId;
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
        public String deleteStockOutLine(Entity.TrnStockOutLine stockOutLine)
        {
            try
            {
                Entity.TrnStockOutLine delete = db.TrnStockOutLine.Where(s => s.Id == stockOutLine.Id).FirstOrDefault<Entity.TrnStockOutLine>();

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

    
