using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/stockCountLine")]
    public class TrnStockCountLineController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnStockCountLine> listStockCountLines()
        {
            var stockCountLines = from d in db.TrnStockCountLine
                                  select new Models.PosTrnStockCountLine
                              {
                                  Id = d.Id,
                                  StockCountId = d.StockCountId,
                                  ItemId = d.ItemId,
                                  UnitId = d.UnitId,
                                  Quantity = d.Quantity,
                                  Cost = d.Cost,
                                  Amount = d.Amount
                              };
            return stockCountLines.ToList();
        }

        [HttpPost, Route("create")]
        public int addStockCountLine(Entity.TrnStockCountLine stockCountLine)
        {
            try
            {

                db.Entry(stockCountLine).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return stockCountLine.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editStockCountLine(Entity.TrnStockCountLine stockCountLine)
        {
            try
            {
                Entity.TrnStockCountLine update = db.TrnStockCountLine.Where(s => s.Id == stockCountLine.Id).FirstOrDefault<Entity.TrnStockCountLine>();

                if (update != null)
                {
                    update.StockCountId = stockCountLine.StockCountId;
                    update.ItemId = stockCountLine.ItemId;
                    update.UnitId = stockCountLine.UnitId;
                    update.Quantity = stockCountLine.Quantity;
                    update.Cost = stockCountLine.Cost;
                    update.Amount = stockCountLine.Amount;
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
        public String deleteStockCountLine(Entity.TrnStockCountLine stockCountLine)
        {
            try
            {
                Entity.TrnStockCountLine delete = db.TrnStockCountLine.Where(s => s.Id == stockCountLine.Id).FirstOrDefault<Entity.TrnStockCountLine>();

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
