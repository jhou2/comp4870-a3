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
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class ChoiceAPIController : ApiController
    {
        private DiplomaContext db = new DiplomaContext();

        // GET api/ChoiceAPI
        public IQueryable<Choice> GetChoices()
        {
            return db.Choices;
        }

        // GET api/ChoiceAPI/5
        [ResponseType(typeof(Choice))]
        public IHttpActionResult GetChoice(int id)
        {
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return NotFound();
            }

            return Ok(choice);
        }

        // PUT api/ChoiceAPI/5
        public IHttpActionResult PutChoice(int id, Choice choice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != choice.ChoiceId)
            {
                return BadRequest();
            }

            db.Entry(choice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoiceExists(id))
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

        // POST api/ChoiceAPI
        [ResponseType(typeof(Choice))]
        public IHttpActionResult PostChoice(ChoiceViewModel choiceView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);
            }

            if(StudentExists(choiceView.StudentNumber))
            {
                return BadRequest("The Student number " + choiceView.StudentNumber + (" has already submit options"));
            }

            List<string> options = new List<string>();
            options.Add(choiceView.FirstChoice);
            options.Add(choiceView.SecondChoice);
            options.Add(choiceView.ThirdChoice);
            options.Add(choiceView.FourthChoice);

            for(int i = 0; i < options.Count; i++)
            {
                for(int j =0; j < options.Count; j++)
                {
                    if(i==j)
                    {
                        continue;
                    }
                    if(options[j].Equals(options[i]))
                    {
                        return BadRequest("Make sure your options are not the same");
                    }
                }
            }

 

            Choice choice = choiceView.toChoice();
            choice.CreateDate = DateTime.Now;
            
            db.Choices.Add(choice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = choice.ChoiceId }, choice);
        }

        // DELETE api/ChoiceAPI/5
        [ResponseType(typeof(Choice))]
        public IHttpActionResult DeleteChoice(int id)
        {
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return NotFound();
            }

            db.Choices.Remove(choice);
            db.SaveChanges();

            return Ok(choice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChoiceExists(int id)
        {
            return db.Choices.Count(e => e.ChoiceId == id) > 0;
        }

        private bool StudentExists(string studentNumber)
        {
            return db.Choices.Count(e => e.StudentNumber == studentNumber) > 0;
        }
    }
}