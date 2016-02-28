using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using betaNana.Models;

namespace betaNana.Controllers
{
    public class QuotesController : ApiController
    {
        private QuotesServiceContext db = new QuotesServiceContext();


        public IQueryable<Quote> Index()
        {
            return db.Quotes;
        }


        /// <summary>
        /// Returns a list of all quotes
        /// </summary>
        /// <returns>Object List</returns>
        public IQueryable<Quote> GetQuotes()
        {
            return db.Quotes;
        }

        /// <summary>
        /// Returns a single quote
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        [ResponseType(typeof(Quote))]
        public async Task<IHttpActionResult> GetQuote(int id)
        {
            Quote quote = await db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            return Ok(quote);
        }

        /// <summary>
        /// Updates a single quote
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quote"></param>
        /// <returns>void</returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuote(int id, Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quote.Id)
            {
                return BadRequest();
            }

            db.Entry(quote).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
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

        /// <summary>
        /// Creates a single new quote
        /// </summary>
        /// <param name="quote"></param>
        /// <returns>Object</returns>
        [ResponseType(typeof(Quote))]
        public async Task<IHttpActionResult> PostQuote(Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quotes.Add(quote);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = quote.Id }, quote);
        }

        /// <summary>
        /// Delete a single quote
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        [ResponseType(typeof(Quote))]
        public async Task<IHttpActionResult> DeleteQuote(int id)
        {
            Quote quote = await db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            db.Quotes.Remove(quote);
            await db.SaveChangesAsync();

            return Ok(quote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteExists(int id)
        {
            return db.Quotes.Count(e => e.Id == id) > 0;
        }
    }
}