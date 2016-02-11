using bingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bingo.Controllers
{
    public class GameController : ApiController
    {
        public Game NewGame(string name)
        {
            return NewGame(name, Game.GetDefaultGame());
        }

        public Game NewGame(string name, List<CellContent> cellContents)
        {
            var game = new Game(name);
            game.CellContents.AddRange(cellContents);

            //TODO: Add the game to the db

            return game;
        }
    }
}
