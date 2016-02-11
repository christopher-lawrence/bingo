using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public List<Cell> Cells { get; set; }
        public string Name { get; set; }
        public GameState State { get; set; }
        public List<Player> Players { get; set; }

        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cells = new List<Cell>();
            State = new GameState();
            Players = new List<Player>();
        }

        public static List<Cell> GetDefaultGame()
        {
            var cells = new List<Cell>();
            foreach (int i in Enumerable.Range(0, 24))
            {
                cells.Add(new Cell { Content = i.ToString() });
            }

            return cells;
        }
    }
}