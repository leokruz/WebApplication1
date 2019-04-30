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
    public class StatusPedidoController : ApiController
    {
        private TccContext db = new TccContext();

        // GET: api/StatusPedido
        public IQueryable<StatusPedido> GetStatusPedido()
        {
            return db.StatusPedido;
        }

        // GET: api/StatusPedido/5
        [ResponseType(typeof(StatusPedido))]
        public IHttpActionResult GetStatusPedido(int id)
        {
            StatusPedido statusPedido = db.StatusPedido.Find(id);
            if (statusPedido == null)
            {
                return NotFound();
            }

            return Ok(statusPedido);
        }

        // PUT: api/StatusPedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusPedido(int id, StatusPedido statusPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusPedido.IdStatusPedido)
            {
                return BadRequest();
            }

            db.Entry(statusPedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusPedidoExists(id))
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

        // POST: api/StatusPedido
        [ResponseType(typeof(StatusPedido))]
        public IHttpActionResult PostStatusPedido(StatusPedido statusPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusPedido.Add(statusPedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusPedido.IdStatusPedido }, statusPedido);
        }

        // DELETE: api/StatusPedido/5
        [ResponseType(typeof(StatusPedido))]
        public IHttpActionResult DeleteStatusPedido(int id)
        {
            StatusPedido statusPedido = db.StatusPedido.Find(id);
            if (statusPedido == null)
            {
                return NotFound();
            }

            db.StatusPedido.Remove(statusPedido);
            db.SaveChanges();

            return Ok(statusPedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusPedidoExists(int id)
        {
            return db.StatusPedido.Count(e => e.IdStatusPedido == id) > 0;
        }
    }
}