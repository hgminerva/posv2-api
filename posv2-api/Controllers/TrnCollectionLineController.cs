using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/transaction/collectionLine")]
    public class TrnCollectionLineController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosTrnCollectionLine> listCollectionLines()
        {
            var collectionLines = from d in db.TrnCollectionLine
                            select new Models.PosTrnCollectionLine
                            {
                                Id = d.Id,
                                CollectionId = d.CollectionId,
                                Amount = d.Amount,
                                PayTypeId = d.PayTypeId,
                                CheckNumber = d.CheckNumber,
                                CheckDate = d.CheckDate,
                                CheckBank = d.CheckBank,
                                CreditCardVerificationCode = d.CreditCardVerificationCode,
                                CreditCardNumber = d.CreditCardNumber,
                                CreditCardType = d.CreditCardType,
                                CreditCardBank = d.CreditCardBank,
                                GiftCertificateNumber = d.GiftCertificateNumber,
                                OtherInformation = d.OtherInformation,
                                StockInId = d.StockInId,
                                AccountId = d.AccountId,
                                CreditCardReferenceNumber = d.CreditCardReferenceNumber,
                                CreditCardHolderName = d.CreditCardHolderName,
                                CreditCardExpiry = d.CreditCardExpiry
                            };
            return collectionLines.ToList();
        }

        [HttpPost, Route("create")]
        public int addCollectionLine(Entity.TrnCollectionLine collectionLine)
        {
            try
            {

                db.Entry(collectionLine).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return collectionLine.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editCollectionLine(Entity.TrnCollectionLine collectionLine)
        {
            try
            {
                Entity.TrnCollectionLine update = db.TrnCollectionLine.Where(s => s.Id == collectionLine.Id).FirstOrDefault<Entity.TrnCollectionLine>();

                if (update != null)
                {
                    update.CollectionId = collectionLine.CollectionId;
                    update.Amount = collectionLine.Amount;
                    update.PayTypeId = collectionLine.PayTypeId;
                    update.CheckNumber = collectionLine.CheckNumber;
                    update.CheckDate = collectionLine.CheckDate;
                    update.CheckBank = collectionLine.CheckBank;
                    update.CreditCardVerificationCode = collectionLine.CreditCardVerificationCode;
                    update.CreditCardNumber = collectionLine.CreditCardNumber;
                    update.CreditCardType = collectionLine.CreditCardType;
                    update.CreditCardBank = collectionLine.CreditCardBank;
                    update.GiftCertificateNumber = collectionLine.GiftCertificateNumber;
                    update.OtherInformation = collectionLine.OtherInformation;
                    update.StockInId = collectionLine.StockInId;
                    update.AccountId = collectionLine.AccountId;
                    update.CreditCardReferenceNumber = collectionLine.CreditCardReferenceNumber;
                    update.CreditCardHolderName = collectionLine.CreditCardHolderName;
                    update.CreditCardExpiry = collectionLine.CreditCardExpiry;
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
        public String deleteCollectionLine(Entity.TrnCollectionLine collectionLine)
        {
            try
            {
                Entity.TrnCollectionLine delete = db.TrnCollectionLine.Where(s => s.Id == collectionLine.Id).FirstOrDefault<Entity.TrnCollectionLine>();

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
