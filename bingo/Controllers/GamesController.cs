using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using bingo.Data;
using bingo.Models;

namespace bingo.Controllers
{
    public class GamesController : ApiController
    {
        private GameContext db = new GameContext();

        /// <summary>
        /// Returns _all_ games
        /// </summary>
        /// <returns>Returns _all_ games</returns>
        [Route("api/Games/all")]
        public IQueryable<Game> GetAllGames()
        {
            return db.Games;
        }

        // GET: api/Games
        /// <summary>
        /// Get all games for the account 
        /// </summary>
        /// <param name="accountId">account id</param>
        /// <returns>Returns all games for the account</returns>
        public IQueryable<Game> GetGames(Guid accountId)
        {
            return db.Games.Where(g => g.AccountId == accountId);
        }

        // GET: api/Games/5
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> GetGame(Guid id)
        {
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // GET: api/Games/new
        //[ResponseType(typeof(Game))]
        /// <summary>
        /// Creates a new game for the account
        /// </summary>
        /// <param name="accountId">account id</param>
        /// <returns>A new default game for the account</returns>
        [Route("api/Games/new")]
        [HttpGet]
        public async Task<IHttpActionResult> NewGame(Guid accountId)
        {
            var game = db.Games.Add(new Game(db)
            {
                Id = Guid.NewGuid(),
                Name = "New Game",
                Header = "New Game",            
                AccountId = accountId,    
            });

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GameExists(game.Id))
                    return Conflict();
                else
                    throw;
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGame(Guid id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.Id)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameExists(game.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> DeleteGame(Guid id)
        {
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            await db.SaveChangesAsync();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(Guid id)
        {
            return db.Games.Count(e => e.Id == id) > 0;
        }
    }
}