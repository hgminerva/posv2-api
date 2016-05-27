using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/MstTable")]
    public class MstTableController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        // GET api/MstTable/PerTableGroup
        [Route("PerTableGroup/{TableGroupId}")]
        public List<Models.PosMstTable> Get(Int32 TableGroupId)
        {
            var tables = from d in db.MstTables
                              orderby d.TableCode
                              where d.TableGroupId == TableGroupId
                              select new Models.PosMstTable
                              {
                                  Id = d.Id,
                                  TableCode = d.TableCode,
                                  TableGroupId = d.TableGroupId,
                                  TableGroup = d.MstTableGroup.TableGroup,
                                  TopLocation = 0,
                                  LeftLocation = 0
                              };
            return tables.ToList();
        }
    }
}
