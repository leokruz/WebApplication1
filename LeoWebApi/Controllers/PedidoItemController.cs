using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LeoDatabase.Models;

namespace LeoWebApi.Controllers
{
    public class PedidoItemController : ApiController
    {
        private TccContext db = new TccContext();

        // GET: api/PedidoItem
        public IQueryable<PedidoItem> GetPedidoItem()
        {
            return db.PedidoItem;
        }

        // GET: api/PedidoItem/5
        [ResponseType(typeof(PedidoItem))]
        public IHttpActionResult GetPedidoItem(int id)
        {
            PedidoItem pedidoItem = db.PedidoItem.Find(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return Ok(pedidoItem);
        }

        // PUT: api/PedidoItem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedidoItem(int id, PedidoItem pedidoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoItem.Id)
            {
                return BadRequest();
            }

            db.Entry(pedidoItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PedidoItem
        [ResponseType(typeof(PedidoItem))]
        public IHttpActionResult PostPedidoItem(PedidoItem pedidoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PedidoItem.Add(pedidoItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidoItem.Id }, pedidoItem);
        }

        // DELETE: api/PedidoItem/5
        [ResponseType(typeof(PedidoItem))]
        public IHttpActionResult DeletePedidoItem(int id)
        {
            PedidoItem pedidoItem = db.PedidoItem.Find(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            db.PedidoItem.Remove(pedidoItem);
            db.SaveChanges();

            return Ok(pedidoItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoItemExists(int id)
        {
            return db.PedidoItem.Count(e => e.Id == id) > 0;
        }
    }
}