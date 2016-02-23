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
using bingo.Data;
using bingo.Models;

namespace bingo.Controllers
{
    public class GameCardsController : ApiController
    {
        private GameContext db = new GameContext();

        // GET: api/GameCards
        public IQueryable<GameCard> GetGameCards()
        {
            return db.GameCards;
        }

        // GET: api/GameCards/5
        [ResponseType(typeof(GameCard))]
        public async Task<IHttpActionResult> GetGameCard(Guid id)
        {
            GameCard gameCard = await db.GameCards.FindAsync(id);
            if (gameCard == null)
            {
                return NotFound();
            }

            return Ok(gameCard);
        }

        // PUT: api/GameCards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGameCard(Guid id, GameCard gameCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameCard.Id)
            {
                return BadRequest();
            }

            db.Entry(gameCard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameCardExists(id))
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

        // POST: api/GameCards
        [ResponseType(typeof(GameCard))]
        public async Task<IHttpActionResult> PostGameCard(GameCard gameCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GameCards.Add(gameCard);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameCardExists(gameCard.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gameCard.Id }, gameCard);
        }

        // DELETE: api/GameCards/5
        [ResponseType(typeof(GameCard))]
        public async Task<IHttpActionResult> DeleteGameCard(Guid id)
        {
            GameCard gameCard = await db.GameCards.FindAsync(id);
            if (gameCard == null)
            {
                return NotFound();
            }

            db.GameCards.Remove(gameCard);
            await db.SaveChangesAsync();

            return Ok(gameCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameCardExists(Guid id)
        {
            return db.GameCards.Count(e => e.Id == id) > 0;
        }
    }
}