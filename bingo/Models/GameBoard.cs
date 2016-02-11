using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class GameBoard
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public BoardState BoardState { get; set; }
        public string Header { get; set; }
    }
}