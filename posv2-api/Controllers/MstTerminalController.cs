using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace posv2_api.Controllers
{
    [RoutePrefix("api/terminal")]
    public class MstTerminalController : ApiController
    {
        private Entity.PosDbContext db = new Entity.PosDbContext();

        [HttpGet, Route("list")]
        public List<Models.PosMstTerminal> listTerminals()
        {
            var terminals = from d in db.MstTerminal
                         select new Models.PosMstTerminal
                              {
                                  Id = d.Id,
                                  Terminal = d.Terminal
                              };
            return terminals.ToList();
        }

        [HttpPost, Route("create")]
        public int addTerminal(Entity.MstTerminal terminal)
        {
            try
            {

                db.Entry(terminal).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return terminal.Id;

            }
            catch
            {
                return 0;
            }
        }

        [HttpPut, Route("update")]
        public String editTerminal(Entity.MstTerminal terminal)
        {
            try
            {
                Entity.MstTerminal update = db.MstTerminal.Where(s => s.Id == terminal.Id).FirstOrDefault<Entity.MstTerminal>();

                if (update != null)
                {
                    update.Terminal = terminal.Terminal;
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
        public String deleteTerminal(Entity.MstTerminal terminal)
        {
            try
            {
                Entity.MstTerminal delete = db.MstTerminal.Where(s => s.Id == terminal.Id).FirstOrDefault<Entity.MstTerminal>();

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
