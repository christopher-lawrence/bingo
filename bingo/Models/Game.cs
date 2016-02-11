using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public List<CellContent> CellContents { get; set; }
        public string Name { get; set; }
        public GameState State { get; set; }
        public List<Player> Players { get; set; }

        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CellContents = new List<CellContent>();
            State = new GameState();
            Players = new List<Player>();
        }

        public static List<CellContent> GetDefaultGame()
        {
            var cellContents = new List<CellContent>();
            foreach (int i in Enumerable.Range(0, 24))
            {
                cellContents.Add(new CellContent { Title = i.ToString() });
            }

            return cellContents;
        }
    }
}