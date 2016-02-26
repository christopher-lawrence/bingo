namespace bingo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CellContent",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        AccountId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.GameCard",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GameId = c.Guid(nullable: false),
                        GameCardStateId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Header = c.String(),
                        AccountId = c.Guid(nullable: false),
                        GameStateId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.GameState",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CurrentState = c.Int(nullable: false),
                        GameId = c.Guid(nullable: false),
                        WinnerId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Player", t => t.WinnerId)
                .ForeignKey("dbo.Game", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.WinnerId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Won = c.Boolean(nullable: false),
                        Game_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.GameCardState",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GameCardId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameCard", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Cell",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Marked = c.Boolean(nullable: false),
                        CellContentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CellContent", t => t.CellContentId, cascadeDelete: true)
                .Index(t => t.CellContentId);
            
            CreateTable(
                "dbo.GameCardCellContents",
                c => new
                    {
                        GameCardRefId = c.Guid(nullable: false),
                        CellContentsRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameCardRefId, t.CellContentsRefId })
                .ForeignKey("dbo.GameCard", t => t.GameCardRefId)
                .ForeignKey("dbo.CellContent", t => t.CellContentsRefId)
                .Index(t => t.GameCardRefId)
                .Index(t => t.CellContentsRefId);
            
            CreateTable(
                "dbo.GameCellContent",
                c => new
                    {
                        GameRefId = c.Guid(nullable: false),
                        CellContentRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameRefId, t.CellContentRefId })
                .ForeignKey("dbo.Game", t => t.GameRefId)
                .ForeignKey("dbo.CellContent", t => t.CellContentRefId)
                .Index(t => t.GameRefId)
                .Index(t => t.CellContentRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cell", "CellContentId", "dbo.CellContent");
            DropForeignKey("dbo.Game", "AccountId", "dbo.Account");
            DropForeignKey("dbo.CellContent", "AccountId", "dbo.Account");
            DropForeignKey("dbo.GameCardState", "Id", "dbo.GameCard");
            DropForeignKey("dbo.GameCard", "GameId", "dbo.Game");
            DropForeignKey("dbo.Player", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.GameState", "Id", "dbo.Game");
            DropForeignKey("dbo.GameState", "WinnerId", "dbo.Player");
            DropForeignKey("dbo.GameCellContent", "CellContentRefId", "dbo.CellContent");
            DropForeignKey("dbo.GameCellContent", "GameRefId", "dbo.Game");
            DropForeignKey("dbo.GameCardCellContents", "CellContentsRefId", "dbo.CellContent");
            DropForeignKey("dbo.GameCardCellContents", "GameCardRefId", "dbo.GameCard");
            DropIndex("dbo.GameCellContent", new[] { "CellContentRefId" });
            DropIndex("dbo.GameCellContent", new[] { "GameRefId" });
            DropIndex("dbo.GameCardCellContents", new[] { "CellContentsRefId" });
            DropIndex("dbo.GameCardCellContents", new[] { "GameCardRefId" });
            DropIndex("dbo.Cell", new[] { "CellContentId" });
            DropIndex("dbo.GameCardState", new[] { "Id" });
            DropIndex("dbo.Player", new[] { "Game_Id" });
            DropIndex("dbo.GameState", new[] { "WinnerId" });
            DropIndex("dbo.GameState", new[] { "Id" });
            DropIndex("dbo.Game", new[] { "AccountId" });
            DropIndex("dbo.GameCard", new[] { "GameId" });
            DropIndex("dbo.CellContent", new[] { "AccountId" });
            DropTable("dbo.GameCellContent");
            DropTable("dbo.GameCardCellContents");
            DropTable("dbo.Cell");
            DropTable("dbo.GameCardState");
            DropTable("dbo.Player");
            DropTable("dbo.GameState");
            DropTable("dbo.Game");
            DropTable("dbo.GameCard");
            DropTable("dbo.CellContent");
            DropTable("dbo.Account");
        }
    }
}
