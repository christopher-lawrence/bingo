namespace bingo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameState", "WinnerId", "dbo.Player");
            DropIndex("dbo.GameState", new[] { "WinnerId" });
            AlterColumn("dbo.GameState", "WinnerId", c => c.Guid());
            AlterColumn("dbo.Game", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.GameState", "WinnerId");
            AddForeignKey("dbo.GameState", "WinnerId", "dbo.Player", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameState", "WinnerId", "dbo.Player");
            DropIndex("dbo.GameState", new[] { "WinnerId" });
            AlterColumn("dbo.Game", "Name", c => c.String());
            AlterColumn("dbo.GameState", "WinnerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.GameState", "WinnerId");
            AddForeignKey("dbo.GameState", "WinnerId", "dbo.Player", "Id", cascadeDelete: true);
        }
    }
}
