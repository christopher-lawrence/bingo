using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class GameCard
    {
        public Guid Id { get; private set; }
        public Guid GameId { get; private set; }
        public Game Game { get; set; }
        public Cell[] Cells { get; private set; }
        public GameCardState BoardState { get; private set; }

        public GameCard(Guid gameId)
        {
            Id = Guid.NewGuid();
            GameId = gameId;
            // TODO - Set Game
        }

        public void SetCells(int[] numbers)
        {
            Cells = numbers.Select(n => new Cell { Content = Game.CellContents[n] }).ToArray();
        }
    }
}