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
using EntityModels;

namespace Assignment3.Controllers
{
    public class TermAPIController : ApiController
    {
        private DiplomaContext db = new DiplomaContext();

        // GET api/TermAPI
        public IQueryable<Term> GetTerms()
        {
            return db.Terms;
        }

        // GET api/TermAPI/active
        [Route("~/api/TermAPI/active")]
        public IQueryable<Term> GetActiveTerms()
        {
            IQueryable<Term> Terms = from t in db.Terms
                                         where t.IsActive == true
                                         select t;
            return Terms;
        }

        // GET api/TermAPI/5
        [ResponseType(typeof(Term))]
        public IHttpActionResult GetTerm(int id)
        {
            Term term = db.Terms.Find(id);
            if (term == null)
            {
                return NotFound();
            }

            return Ok(term);
        }

        // PUT api/TermAPI/5
        public IHttpActionResult PutTerm(int id, Term term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != term.TermCode)
            {
                return BadRequest();
            }

            db.Entry(term).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermExists(id))
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

        // POST api/TermAPI
        [ResponseType(typeof(Term))]
        public IHttpActionResult PostTerm(Term term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Terms.Add(term);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = term.TermCode }, term);
        }

        // DELETE api/TermAPI/5
        [ResponseType(typeof(Term))]
        public IHttpActionResult DeleteTerm(int id)
        {
            Term term = db.Terms.Find(id);
            if (term == null)
            {
                return NotFound();
            }

            db.Terms.Remove(term);
            db.SaveChanges();

            return Ok(term);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TermExists(int id)
        {
            return db.Terms.Count(e => e.TermCode == id) > 0;
        }
    }
}