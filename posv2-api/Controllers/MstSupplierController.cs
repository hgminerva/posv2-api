using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/supplier")]
    public class MstSupplierController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstSupplier> listSuppliers()
        {
            var suppliers = from d in db.MstSupplier
                         select new Models.PosMstSupplier
                              {
                                    Id = d.Id,
                                    Supplier = d.Supplier,
                                    Address = d.Address,
                                    TelephoneNumber = d.TelephoneNumber,
                                    CellphoneNumber = d.CellphoneNumber,
                                    FaxNumber = d.FaxNumber,
                                    TermId = d.TermId,
                                    TIN = d.TIN,
                                    AccountId = d.AccountId,
                                    EntryUserId = d.EntryUserId,
                                    EntryDateTime = d.EntryDateTime,
                                    UpdateUserId = d.UpdateUserId,
                                    UpdateDateTime = d.UpdateDateTime,
                                    IsLocked = d.IsLocked
                              };
            return suppliers.ToList();
        }

        [HttpPost, Route("create")]
        public int addSupplier(Entity.MstSupplier supplier)
        {
            try
            {

                db.Entry(supplier).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return supplier.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editSupplier(Entity.MstSupplier supplier)
        {
            try
            {
                Entity.MstSupplier update = db.MstSupplier.Where(s => s.Id == supplier.Id).FirstOrDefault<Entity.MstSupplier>();

                if (update != null)
                {
                    update.Supplier = supplier.Supplier;
                    update.Address = supplier.Address;
                    update.TelephoneNumber = supplier.TelephoneNumber;
                    update.CellphoneNumber = supplier.CellphoneNumber;
                    update.FaxNumber = supplier.FaxNumber;
                    update.TermId = supplier.TermId;
                    update.TIN = supplier.TIN;
                    update.AccountId = supplier.AccountId;
                    update.EntryUserId = supplier.EntryUserId;
                    update.EntryDateTime = supplier.EntryDateTime;
                    update.UpdateUserId = supplier.UpdateUserId;
                    update.UpdateDateTime = supplier.UpdateDateTime;
                    update.IsLocked = supplier.IsLocked;
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
        public String deleteSupplier(Entity.MstSupplier supplier)
        {
            try
            {
                Entity.MstSupplier delete = db.MstSupplier.Where(s => s.Id == supplier.Id).FirstOrDefault<Entity.MstSupplier>();

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
