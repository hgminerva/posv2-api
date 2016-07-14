using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/stockInLine")]
    public class TrnStockInLineController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnStockInLine> listStockInLines()
        {
            var stockInLines = from d in db.TrnStockInLine
                               select new Models.PosTrnStockInLine
                              {
                                  Id = d.Id,
                                  StockInId = d.StockInId,
                                  ItemId = d.ItemId,
                                  UniteId = d.UniteId,
                                  Quantity = d.Quantity,
                                  Cost = d.Cost,
                                  Amount = d.Amount,
                                  ExpiryDate = d.ExpiryDate,
                                  LotNumber = d.LotNumber,
                                  AssetAccountId = d.AssetAccountId
                              };
            return stockInLines.ToList();
        }

        [HttpPost, Route("create")]
        public int addStockInLine(Entity.TrnStockInLine stockInLine)
        {
            try
            {

                db.Entry(stockInLine).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return stockInLine.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editStockInLine(Entity.TrnStockInLine stockInLine)
        {
            try
            {
                Entity.TrnStockInLine update = db.TrnStockInLine.Where(s => s.Id == stockInLine.Id).FirstOrDefault<Entity.TrnStockInLine>();

                if (update != null)
                {
                    update.StockInId = stockInLine.StockInId;
                    update.ItemId = stockInLine.ItemId;
                    update.UniteId = stockInLine.UniteId;
                    update.Quantity = stockInLine.Quantity;
                    update.Cost = stockInLine.Cost;
                    update.Amount = stockInLine.Amount;
                    update.ExpiryDate = stockInLine.ExpiryDate;
                    update.LotNumber = stockInLine.LotNumber;
                    update.AssetAccountId = stockInLine.AssetAccountId;
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
        public String deleteStockInLine(Entity.TrnStockInLine stockInLine)
        {
            try
            {
                Entity.TrnStockInLine delete = db.TrnStockInLine.Where(s => s.Id == stockInLine.Id).FirstOrDefault<Entity.TrnStockInLine>();

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
