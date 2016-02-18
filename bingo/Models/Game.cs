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
        public string Header { get; set; }

        public Game(string name) : this(name, GetDefaultGame())
        { }

        public Game(string name, List<CellContent> cells)
        {
            Id = Guid.NewGuid();
            Name = name;
            CellContents = new List<CellContent>(cells);
            State = new GameState();
            Players = new List<Player>();

            // Save to DB
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

        public GameCard NewGameCard()
        {
            var card = new GameCard(Id);
            card.SetCells(GetRandomNumbers());

            return card;
        }

        private int[] GetRandomNumbers(int count = Constants.DefaultGameSize)
        {
            //TODO - could definitely make this stronger
            var rand = new Random((int)DateTime.Now.Ticks);
            var numbers = new int[count];

            foreach (int i in Enumerable.Range(0, count))
                numbers[i] = rand.Next(0, CellContents.Count-1);

            return numbers;
        }
    }
}