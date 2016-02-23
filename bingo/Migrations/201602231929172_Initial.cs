namespace bingo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CellContent",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Game_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.GameCard",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GameId = c.Guid(nullable: false),
                        BoardState_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameCardState", t => t.BoardState_Id)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.BoardState_Id);
            
            CreateTable(
                "dbo.GameCardState",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        State_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameState", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.GameState",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CurrentState = c.Int(nullable: false),
                        WinnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Player", t => t.WinnerId, cascadeDelete: true)
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
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        GameStateId = c.Guid(nullable: false),
                        Header = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameState", t => t.GameStateId, cascadeDelete: true)
                .Index(t => t.GameStateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameCard", "GameId", "dbo.Game");
            DropForeignKey("dbo.Player", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.Game", "GameStateId", "dbo.GameState");
            DropForeignKey("dbo.CellContent", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.GameCard", "BoardState_Id", "dbo.GameCardState");
            DropForeignKey("dbo.GameCardState", "State_Id", "dbo.GameState");
            DropForeignKey("dbo.GameState", "WinnerId", "dbo.Player");
            DropIndex("dbo.Game", new[] { "GameStateId" });
            DropIndex("dbo.Player", new[] { "Game_Id" });
            DropIndex("dbo.GameState", new[] { "WinnerId" });
            DropIndex("dbo.GameCardState", new[] { "State_Id" });
            DropIndex("dbo.GameCard", new[] { "BoardState_Id" });
            DropIndex("dbo.GameCard", new[] { "GameId" });
            DropIndex("dbo.CellContent", new[] { "Game_Id" });
            DropTable("dbo.Game");
            DropTable("dbo.Player");
            DropTable("dbo.GameState");
            DropTable("dbo.GameCardState");
            DropTable("dbo.GameCard");
            DropTable("dbo.CellContent");
        }
    }
}
