namespace bingo.Migrations
{
    using System.Data.Entity.Migrations;
    using bingo.Models;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<bingo.Data.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bingo.Data.GameContext context)
        {
            foreach (int i in Enumerable.Range(0, 24))
            {
                context.CellContents.AddOrUpdate(cc => cc.Id, new CellContent { Id = System.Guid.NewGuid(), Title = i.ToString() });
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
