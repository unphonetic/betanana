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
    public class QuoteDetailsController : ApiController
    {
        private QuotesServiceContext db = new QuotesServiceContext();

        // GET: api/QuoteDetails
        public IQueryable<QuoteDetail> GetQuoteDetails()
        {
            return db.QuoteDetails;
        }

        /// <summary>
        /// Retrieves a single quote detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        [ResponseType(typeof(QuoteDetail))]
        public async Task<IHttpActionResult> GetQuoteDetail(int id)
        {
            QuoteDetail quoteDetail = await db.QuoteDetails.FindAsync(id);
            if (quoteDetail == null)
            {
                return NotFound();
            }

            return Ok(quoteDetail);
        }

        /// <summary>
        /// Updates a single quote detail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quoteDetail"></param>
        /// <returns>void</returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuoteDetail(int id, QuoteDetail quoteDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quoteDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(quoteDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteDetailExists(id))
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
        /// Creates a new quote detail.  Quote Id is required.
        /// </summary>
        /// <param name="quoteDetail"></param>
        /// <returns>Object</returns>
        [ResponseType(typeof(QuoteDetail))]
        public async Task<IHttpActionResult> PostQuoteDetail(QuoteDetail quoteDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuoteDetails.Add(quoteDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = quoteDetail.Id }, quoteDetail);
        }

        /// <summary>
        /// Deletes a quote detail by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(QuoteDetail))]
        public async Task<IHttpActionResult> DeleteQuoteDetail(int id)
        {
            QuoteDetail quoteDetail = await db.QuoteDetails.FindAsync(id);
            if (quoteDetail == null)
            {
                return NotFound();
            }

            db.QuoteDetails.Remove(quoteDetail);
            await db.SaveChangesAsync();

            return Ok(quoteDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteDetailExists(int id)
        {
            return db.QuoteDetails.Count(e => e.Id == id) > 0;
        }
    }
}