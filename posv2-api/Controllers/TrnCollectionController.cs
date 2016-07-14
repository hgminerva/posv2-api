using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/collection")]
    public class TrnCollectionController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnCollection> listCollections()
        {
            var collections = from d in db.TrnCollection
                            select new Models.PosTrnCollection
                            {
                                Id = d.Id,
                                PeriodId = d.PeriodId,
                                CollectionDate = d.CollectionDate,
                                CollectionNumber = d.CollectionNumber,
                                TerminalId = d.TerminalId,
                                ManualORNumber = d.ManualORNumber,
                                CustomerId = d.CustomerId,
                                Remarks = d.Remarks,
                                SalesId = d.SalesId,
                                SalesBalanceAmount = d.SalesBalanceAmount,
                                Amount = d.Amount,
                                TenderAmount = d.TenderAmount,
                                ChangeAmount = d.ChangeAmount,
                                PreparedBy = d.PreparedBy,
                                CheckedBy = d.CheckedBy,
                                ApprovedBy = d.ApprovedBy,
                                IsCancelled = d.IsCancelled,
                                IsLocked = d.IsLocked,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = d.EntryDateTime,
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = d.UpdateDateTime,
                            };
            return collections.ToList();
        }

        [HttpPost, Route("create")]
        public int addCollection(Entity.TrnCollection collection)
        {
            try
            {

                db.Entry(collection).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return collection.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editCollection(Entity.TrnCollection collection)
        {
            try
            {
                Entity.TrnCollection update = db.TrnCollection.Where(s => s.Id == collection.Id).FirstOrDefault<Entity.TrnCollection>();

                if (update != null)
                {
                    update.PeriodId = collection.PeriodId;
                    update.CollectionDate = collection.CollectionDate;
                    update.CollectionNumber = collection.CollectionNumber;
                    update.TerminalId = collection.TerminalId;
                    update.ManualORNumber = collection.ManualORNumber;
                    update.CustomerId = collection.CustomerId;
                    update.Remarks = collection.Remarks;
                    update.SalesId = collection.SalesId;
                    update.SalesBalanceAmount = collection.SalesBalanceAmount;
                    update.Amount = collection.Amount;
                    update.TenderAmount = collection.TenderAmount;
                    update.ChangeAmount = collection.ChangeAmount;
                    update.PreparedBy = collection.PreparedBy;
                    update.CheckedBy = collection.CheckedBy;
                    update.ApprovedBy = collection.ApprovedBy;
                    update.IsCancelled = collection.IsCancelled;
                    update.IsLocked = collection.IsLocked;
                    update.EntryUserId = collection.EntryUserId;
                    update.EntryDateTime = collection.EntryDateTime;
                    update.UpdateUserId = collection.UpdateUserId;
                    update.UpdateDateTime = collection.UpdateDateTime;
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
        public String deleteCollection(Entity.TrnCollection collection)
        {
            try
            {
                Entity.TrnCollection delete = db.TrnCollection.Where(s => s.Id == collection.Id).FirstOrDefault<Entity.TrnCollection>();

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
