using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/userForm")]
    public class MstUserFormController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstUserForm> listUserForms()
        {
            var userForms = from d in db.MstUserForm
                        select new Models.PosMstUserForm
                        {
                            Id = d.Id,
                            FormId = d.FormId,
                            UserId = d.UserId,
                            CanDelete = d.CanDelete,
                            CanAdd = d.CanAdd,
                            CanLock = d.CanLock,
                            CanUnlock = d.CanUnlock,
                            CanPrint = d.CanPrint,
                            CanPreview = d.CanPreview,
                            CanEdit = d.CanEdit,
                            CanTender = d.CanTender,
                            CanDiscount = d.CanDiscount,
                            CanView = d.CanView,
                            CanSplit = d.CanSplit,
                            CanCancel = d.CanCancel,
                            CanReturn = d.CanReturn
                        };
            return userForms.ToList();
        }

        [HttpPost, Route("create")]
        public int addUserForm(Entity.MstUserForm userForm)
        {
            try
            {

                db.Entry(userForm).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return userForm.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editUserForm(Entity.MstUserForm userForm)
        {
            try
            {
                Entity.MstUserForm update = db.MstUserForm.Where(s => s.Id == userForm.Id).FirstOrDefault<Entity.MstUserForm>();

                if (update != null)
                {
                    update.FormId = userForm.FormId;
                    update.UserId = userForm.UserId;
                    update.CanDelete = userForm.CanDelete;
                    update.CanAdd = userForm.CanAdd;
                    update.CanLock = userForm.CanLock;
                    update.CanUnlock = userForm.CanUnlock;
                    update.CanPrint = userForm.CanPrint;
                    update.CanPreview = userForm.CanPreview;
                    update.CanEdit = userForm.CanEdit;
                    update.CanTender = userForm.CanTender;
                    update.CanDiscount = userForm.CanDiscount;
                    update.CanView = userForm.CanView;
                    update.CanSplit = userForm.CanSplit;
                    update.CanCancel = userForm.CanCancel;
                    update.CanReturn = userForm.CanReturn;
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
        public String deleteUserForm(Entity.MstUserForm userForm)
        {
            try
            {
                Entity.MstUserForm delete = db.MstUserForm.Where(s => s.Id == userForm.Id).FirstOrDefault<Entity.MstUserForm>();

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
