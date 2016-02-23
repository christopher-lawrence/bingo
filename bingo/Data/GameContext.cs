using bingo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace bingo.Data
{
    public class GameContext : DbContext
    {
        private static GameContext _context = null;

        public GameContext() : base("name=Bingo")
        {
        }

        public static GameContext GetContext()
        {
            return _context ?? (_context = new GameContext());
        }
        
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCard> GameCards { get; set; }
        public DbSet<CellContent> CellContents { get; set; }
        //public DbSet<Cell> Cells { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<GameCardState> GameCardStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}