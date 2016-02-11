using bingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bingo.Controllers
{
    public class GameBoardController : ApiController
    {
        /// <summary>
        /// Return an existing game board
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GameBoard GetGameBoard(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a new game board based on game id
        /// </summary>
        /// <param name="gameId">The game id to use</param>
        /// <returns>A new game board based on game id</returns>
        public GameBoard NewGameBoard(string gameId)
        {
            throw new NotImplementedException();
        }
    }
}
