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
        
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCard> GameCards { get; set; }
        public DbSet<CellContent> CellContents { get; set; }
        //public DbSet<Cell> Cells { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<GameCardState> GameCardStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            // Primary keys
            modelBuilder.Entity<Account>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Cell>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<CellContent>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Game>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<GameState>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<GameCard>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<GameCardState>()
                .HasKey(t => t.Id);

            // Account to Games
            modelBuilder.Entity<Account>()
                .HasMany<Game>(s => s.Games)
                .WithRequired(s => s.Account)
                .HasForeignKey(s => s.AccountId)
                .WillCascadeOnDelete(false);

            // Account to CellContents
            modelBuilder.Entity<Account>()
                .HasMany(s => s.CellContents)
                .WithRequired(s => s.Account)
                .HasForeignKey(s => s.AccountId)
                .WillCascadeOnDelete(false);

            // Games to CellContents
            modelBuilder.Entity<Game>()
                .HasMany(t => t.CellContents)
                .WithMany(t => t.Games)
                .Map(m =>
                {
                    m.MapLeftKey("GameRefId");
                    m.MapRightKey("CellContentRefId");
                    m.ToTable("GameCellContent");
                });

            // Game to GameState
            modelBuilder.Entity<Game>()
                .HasRequired(t => t.GameState)
                .WithRequiredPrincipal(t => t.Game);

            // GameCard to Game
            modelBuilder.Entity<GameCard>()
                .HasRequired(t => t.Game);
            
            // GameCardState to GameCard
            modelBuilder.Entity<GameCard>()
                .HasRequired(t => t.GameCardState)
                .WithRequiredPrincipal(t => t.GameCard);

            // GameCard to CellContent
            modelBuilder.Entity<GameCard>()
                .HasMany(t => t.CellContents)
                .WithMany(t => t.GameCards)
                .Map(m =>
                {
                    m.MapLeftKey("GameCardRefId");
                    m.MapRightKey("CellContentsRefId");
                    m.ToTable("GameCardCellContents");
                });
                
        }
    }
}