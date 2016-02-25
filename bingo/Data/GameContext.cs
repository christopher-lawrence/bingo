using bingo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

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
            
            // Primary keys
            modelBuilder.Entity<Account>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Game>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<CellContent>()
                .HasKey(t => t.Id);

            // Account to Games
            modelBuilder.Entity<Account>()
                .HasMany<Game>(s => s.Games)
                .WithRequired(s => s.Account)
                .HasForeignKey(s => s.AccountId);

            // Account to CellContents
            modelBuilder.Entity<Account>()
                .HasMany(s => s.CellContents)
                .WithRequired(s => s.Account)
                .HasForeignKey(s => s.AccountId);

            // Games to CellContents
            modelBuilder.Entity<Game>()
                .HasMany(t => t.CellContents)
                .WithMany(t => t.Game)
                .Map(m =>
                {
                    m.MapLeftKey("GameRefId");
                    m.MapRightKey("CellContentRefId");
                    m.ToTable("GameCellContent");
                });

            // Game to GameState
            modelBuilder.Entity<Game>()
                .HasRequired(t => t.GameState)
                .WithRequiredPrincipal();

            // GameCard to Game
            modelBuilder.Entity<GameCard>()
                .HasRequired(t => t.Game);

            // GameCard to GameCardState
            modelBuilder.Entity<GameCard>()
                .HasRequired(t => t.GameCardState)
                .WithRequiredPrincipal(t => t.GameCard);
            
        }
    }
}