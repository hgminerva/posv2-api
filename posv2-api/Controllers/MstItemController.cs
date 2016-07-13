using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/item")]
    public class MstItemController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstItem> listItems()
        {
            var items = from d in db.MstItem
                    select new Models.PosMstItem
                    {
                        Id = d.Id,
                        ItemCode = d.ItemCode,
                        BarCode = d.BarCode,
                        ItemDescription = d.ItemDescription,
                        Alias = d.Alias,
                        GenericName = d.GenericName,
                        Category = d.Category,
                        SalesAccountId = d.SalesAccountId,
                        AssetAccountId = d.AssetAccountId,
                        CostAccountId = d.CostAccountId,
                        InTaxId = d.InTaxId,
                        OutTaxId = d.OutTaxId,
                        UnitId = d.UnitId,
                        DefaultSupplierId = d.DefaultSupplierId,
                        Cost = d.Cost,
                        MarkUp = d.MarkUp,
                        Price = d.Price,
                        ImagePath = d.ImagePath,
                        ReorderQuantity = d.ReorderQuantity,
                        OnhandQuantity = d.OnhandQuantity,
                        IsInventory = d.IsInventory,
                        ExpiryDate = d.ExpiryDate,
                        LotNumber = d.LotNumber,
                        Remarks = d.Remarks,
                        EntryUserId = d.EntryUserId,
                        EntryDateTime = d.EntryDateTime,
                        UpdateUserId = d.UpdateUserId,
                        UpdateDateTime = d.UpdateDateTime,
                        isLocked = d.isLocked,
                        DefaultKitchenReport = d.DefaultKitchenReport,
                        IsPackage = d.IsPackage,
                    };
            return items.ToList();
        }

        [HttpPost, Route("create")]
        public int addItem(Entity.MstItem item)
        {
            try
            {

                db.Entry(item).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return item.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editItem(Entity.MstItem item)
        {
            try
            {
                Entity.MstItem update = db.MstItem.Where(s => s.Id == item.Id).FirstOrDefault<Entity.MstItem>();

                if (update != null)
                {
                    update.ItemCode = item.ItemCode;
                    update.BarCode = item.BarCode;
                    update.ItemDescription = item.ItemDescription;
                    update.Alias = item.Alias;
                    update.GenericName = item.GenericName;
                    update.Category = item.Category;
                    update.SalesAccountId = item.SalesAccountId;
                    update.AssetAccountId = item.AssetAccountId;
                    update.CostAccountId = item.CostAccountId;
                    update.InTaxId = item.InTaxId;
                    update.OutTaxId = item.OutTaxId;
                    update.UnitId = item.UnitId;
                    update.DefaultSupplierId = item.DefaultSupplierId;
                    update.Cost = item.Cost;
                    update.MarkUp = item.MarkUp;
                    update.Price = item.Price;
                    update.ImagePath = item.ImagePath;
                    update.ReorderQuantity = item.ReorderQuantity;
                    update.OnhandQuantity = item.OnhandQuantity;
                    update.IsInventory = item.IsInventory;
                    update.ExpiryDate = item.ExpiryDate;
                    update.LotNumber = item.LotNumber;
                    update.Remarks = item.Remarks;
                    update.EntryUserId = item.EntryUserId;
                    update.EntryDateTime = item.EntryDateTime;
                    update.UpdateUserId = item.UpdateUserId;
                    update.UpdateDateTime = item.UpdateDateTime;
                    update.isLocked = item.isLocked;
                    update.DefaultKitchenReport = item.DefaultKitchenReport;
                    update.IsPackage = item.IsPackage;
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
        public String deleteItem(Entity.MstItem item)
        {
            try
            {
                Entity.MstItem delete = db.MstItem.Where(s => s.Id == item.Id).FirstOrDefault<Entity.MstItem>();

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
