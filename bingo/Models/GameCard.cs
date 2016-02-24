using bingo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class GameCard
    {
        // Properties
        private GameContext _context { get; set; }
        public Guid Id { get; private set; }
        public int[] CellContentOrder { get; set; }

        // Relations
        public virtual Game Game { get; set; }
        // TODO - Might not be necessary -- Can be obtained from Game
        public virtual ICollection<CellContent> CellContents { get; set; }
        //public Cell[] Cells { get; private set; }
        public virtual GameCardState GameCardState { get; set; }

        public GameCard(GameContext context, Guid gameId)
        {
            Id = Guid.NewGuid();
            _context = context;
            Game = _context.Games.SingleOrDefault(g => g.Id == gameId);
            CellContents = Game.CellContents;
            _context.GameCards.Add(this);
            _context.SaveChanges();
        }

        public void SetCells(int[] numbers)
        {
            CellContentOrder = numbers;
        }
    }
}