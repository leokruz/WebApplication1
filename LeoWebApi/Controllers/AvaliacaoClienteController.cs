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
    public class AvaliacaoClienteController : ApiController
    {
        private TccContext db = new TccContext();

        // GET: api/AvaliacaoCliente
        public IQueryable<AvaliacaoCliente> GetAvaliacoesCliente()
        {
            return db.AvaliacoesCliente;
        }

        // GET: api/AvaliacaoCliente/5
        [ResponseType(typeof(AvaliacaoCliente))]
        public IHttpActionResult GetAvaliacaoCliente(int id)
        {
            AvaliacaoCliente avaliacaoCliente = db.AvaliacoesCliente.Find(id);
            if (avaliacaoCliente == null)
            {
                return NotFound();
            }

            return Ok(avaliacaoCliente);
        }

        // PUT: api/AvaliacaoCliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAvaliacaoCliente(int id, AvaliacaoCliente avaliacaoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avaliacaoCliente.Id)
            {
                return BadRequest();
            }

            db.Entry(avaliacaoCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoClienteExists(id))
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

        // POST: api/AvaliacaoCliente
        [ResponseType(typeof(AvaliacaoCliente))]
        public IHttpActionResult PostAvaliacaoCliente(AvaliacaoCliente avaliacaoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AvaliacoesCliente.Add(avaliacaoCliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = avaliacaoCliente.Id }, avaliacaoCliente);
        }

        // DELETE: api/AvaliacaoCliente/5
        [ResponseType(typeof(AvaliacaoCliente))]
        public IHttpActionResult DeleteAvaliacaoCliente(int id)
        {
            AvaliacaoCliente avaliacaoCliente = db.AvaliacoesCliente.Find(id);
            if (avaliacaoCliente == null)
            {
                return NotFound();
            }

            db.AvaliacoesCliente.Remove(avaliacaoCliente);
            db.SaveChanges();

            return Ok(avaliacaoCliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AvaliacaoClienteExists(int id)
        {
            return db.AvaliacoesCliente.Count(e => e.Id == id) > 0;
        }
    }
}