using bingo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace bingo.Models
{
    public class Game
    {
        private GameContext _context { get; set; }
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }        
        public string Header { get; set; }

        // Foreign keys
        public Guid AccountId { get; set; }
        public Guid GameStateId { get; set; }

        // Navigation
        public virtual Account Account { get; set; }
        public virtual GameState GameState { get; set; }
        public virtual ICollection<CellContent> CellContents { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public Game(GameContext context) : this(context, GetDefaultGame())
        { }

        public Game(GameContext context, List<CellContent> cells)
        {
            Id = Guid.NewGuid();
            CellContents = new List<CellContent>(cells);
            GameState = new GameState();
            Players = new List<Player>();
            _context = context;
            // Save to DB
            //GameCards = new List<GameCard>();
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

        public async Task<GameCard> NewGameCard()
        {
            var card = new GameCard(_context, Id);
            card.SetCells(GetRandomNumbers());

            _context.GameCards.Add(card);
            await _context.SaveChangesAsync();
                        
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