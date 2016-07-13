using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/salesDraft")]
    public class TrnSalesDraftController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnSalesDraft> listSalesDrafts()
        {
            var salesDrafts = from d in db.TrnSalesDraft
                         select new Models.PosTrnSalesDraft
                              {
                                  Id = d.Id,
                                  DocRef = d.DocRef,
                                  DocDate = d.DocDate,
                                  ItemCode = d.ItemCode,
                                  ItemId = d.ItemId,
                                  Price = d.Price,
                                  Quantity = d.Quantity,
                                  Amount = d.Amount,
                                  CustomerCode = d.CustomerCode,
                                  Customer = d.Customer,
                                  ContactPerson = d.ContactPerson,
                                  Address = d.Address,
                                  PhoneNumber = d.PhoneNumber,
                                  MobilePhoneNumber = d.MobilePhoneNumber
                              };
            return salesDrafts.ToList();
        }

        [HttpPost, Route("create")]
        public int addSalesDraft(Entity.TrnSalesDraft salesDraft)
        {
            try
            {

                db.Entry(salesDraft).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return salesDraft.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editSalesDraft(Entity.TrnSalesDraft salesDraft)
        {
            try
            {
                Entity.TrnSalesDraft update = db.TrnSalesDraft.Where(s => s.Id == salesDraft.Id).FirstOrDefault<Entity.TrnSalesDraft>();

                if (update != null)
                {
                    update.DocRef = salesDraft.DocRef;
                    update.DocDate = salesDraft.DocDate;
                    update.ItemCode = salesDraft.ItemCode;
                    update.ItemId = salesDraft.ItemId;
                    update.Price = salesDraft.Price;
                    update.Quantity = salesDraft.Quantity;
                    update.Amount = salesDraft.Amount;
                    update.CustomerCode = salesDraft.CustomerCode;
                    update.Customer = salesDraft.Customer;
                    update.ContactPerson = salesDraft.ContactPerson;
                    update.Address = salesDraft.Address;
                    update.PhoneNumber = salesDraft.PhoneNumber;
                    update.MobilePhoneNumber = salesDraft.MobilePhoneNumber;
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
        public String deleteSalesDraft(Entity.TrnSalesDraft salesDraft)
        {
            try
            {
                Entity.TrnSalesDraft delete = db.TrnSalesDraft.Where(s => s.Id == salesDraft.Id).FirstOrDefault<Entity.TrnSalesDraft>();

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
