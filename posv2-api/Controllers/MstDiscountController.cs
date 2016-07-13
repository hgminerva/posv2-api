using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/discount")]
    public class MstDiscountController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstDiscount> listDiscounts()
        {
            var discounts = from d in db.MstDiscount
                            select new Models.PosMstDiscount
                            {
                                Id = d.Id,
                                Discount = d.Discount,
                                DiscountRate = d.DiscountRate,
                                IsVatExempt = d.IsVatExempt,
                                IsDateScheduled = d.IsDateScheduled,
                                DateStart = d.DateStart,
                                DateEnd = d.DateEnd,
                                IsTimeScheduled = d.IsTimeScheduled,
                                TimeStart = d.TimeStart,
                                TimeEnd = d.TimeEnd,
                                IsDayScheduled = d.IsDayScheduled,
                                DayMon = d.DayMon,
                                DayTue = d.DayTue,
                                DayWed = d.DayWed,
                                DayThu = d.DayThu,
                                DayFri = d.DayFri,
                                DaySat = d.DaySat,
                                DaySun = d.DaySun,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = d.EntryDateTime,
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = d.UpdateDateTime,
                                IsLocked = d.IsLocked
                            };
            return discounts.ToList();
        }

        [HttpPost, Route("create")]
        public int addDiscount(Entity.MstDiscount discount)
        {
            try
            {

                db.Entry(discount).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return discount.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editDiscount(Entity.MstDiscount discount)
        {
            try
            {
                Entity.MstDiscount update = db.MstDiscount.Where(s => s.Id == discount.Id).FirstOrDefault<Entity.MstDiscount>();

                if (update != null)
                {
                    update.Discount = discount.Discount;
                    update.DiscountRate = discount.DiscountRate;
                    update.IsVatExempt = discount.IsVatExempt;
                    update.IsDateScheduled = discount.IsDateScheduled;
                    update.DateStart = discount.DateStart;
                    update.DateEnd = discount.DateEnd;
                    update.IsTimeScheduled = discount.IsTimeScheduled;
                    update.TimeStart = discount.TimeStart;
                    update.TimeEnd = discount.TimeEnd;
                    update.IsDayScheduled = discount.IsDayScheduled;
                    update.DayMon = discount.DayMon;
                    update.DayTue = discount.DayTue;
                    update.DayWed = discount.DayWed;
                    update.DayThu = discount.DayThu;
                    update.DayFri = discount.DayFri;
                    update.DaySat = discount.DaySat;
                    update.DaySun = discount.DaySun;
                    update.EntryUserId = discount.EntryUserId;
                    update.EntryDateTime = discount.EntryDateTime;
                    update.UpdateUserId = discount.UpdateUserId;
                    update.UpdateDateTime = discount.UpdateDateTime;
                    update.IsLocked = discount.IsLocked;
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
        public String deleteDiscount(Entity.MstDiscount discount)
        {
            try
            {
                Entity.MstDiscount delete = db.MstDiscount.Where(s => s.Id == discount.Id).FirstOrDefault<Entity.MstDiscount>();

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
