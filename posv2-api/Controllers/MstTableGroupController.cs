using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [Authorize]
    public class MstTableGroupController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        // GET api/MstTableGroup
        public List<Models.PosMstTableGroup> Get()
        {
            var tableGroups = from d in db.MstTableGroups
                              orderby d.TableGroup
                              where d.TableGroup != "Walk-in" && d.TableGroup != "Delivery"
                              select new Models.PosMstTableGroup
                              {
                                  Id = d.Id,
                                  TableGroup = d.TableGroup,
                                  EntryUserId = d.EntryUserId,
                                  EntryDateTime = d.EntryDateTime,
                                  UpdateUserId = d.UpdateUserId,
                                  UpdateDateTime = d.UpdateDateTime,
                                  IsLocked = d.IsLocked
                              };
            return tableGroups.ToList();
        }

    }
}
