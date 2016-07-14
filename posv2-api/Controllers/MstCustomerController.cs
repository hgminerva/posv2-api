using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/customer")]
    public class MstCustomerController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstCustomer> listCustomers()
        {
            var customers = from d in db.MstCustomer
                            select new Models.PosMstCustomer
                            {
                                Id = d.Id,
                                Customer = d.Customer,
                                Address = d.Address,
                                ContactPerson = d.ContactPerson,
                                ContactNumber = d.ContactNumber,
                                CreditLimit = d.CreditLimit,
                                TermId = d.TermId,
                                TIN = d.TIN,
                                WithReward = d.WithReward,
                                RewardNumber = d.RewardNumber,
                                RewardConversion = d.RewardConversion,
                                AccountId = d.AccountId,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = d.EntryDateTime,
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = d.UpdateDateTime,
                                IsLocked = d.IsLocked,
                                DefaultPriceDescription = d.DefaultPriceDescription
                            };

            return customers.ToList();
        }

        [HttpPost, Route("create")]
        public int addCustomer(Entity.MstCustomer customer)
        {
            try
            {

                db.Entry(customer).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return customer.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editCustomer(Entity.MstCustomer customer)
        {
            try
            {
                Entity.MstCustomer update = db.MstCustomer.Where(s => s.Id == customer.Id).FirstOrDefault<Entity.MstCustomer>();

                if (update != null)
                {
                    update.Customer = customer.Customer;
                    update.Address = customer.Address;
                    update.ContactPerson = customer.ContactPerson;
                    update.ContactNumber = customer.ContactNumber;
                    update.CreditLimit = customer.CreditLimit;
                    update.TermId = customer.TermId;
                    update.TIN = customer.TIN;
                    update.WithReward = customer.WithReward;
                    update.RewardNumber = customer.RewardNumber;
                    update.RewardConversion = customer.RewardConversion;
                    update.AccountId = customer.AccountId;
                    update.EntryUserId = customer.EntryUserId;
                    update.EntryDateTime = customer.EntryDateTime;
                    update.UpdateUserId = customer.UpdateUserId;
                    update.UpdateDateTime = customer.UpdateDateTime;
                    update.IsLocked = customer.IsLocked;
                    update.DefaultPriceDescription = customer.DefaultPriceDescription;
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
        public String deleteCustomer(Entity.MstCustomer customer)
        {
            try
            {
                Entity.MstCustomer delete = db.MstCustomer.Where(s => s.Id == customer.Id).FirstOrDefault<Entity.MstCustomer>();

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
