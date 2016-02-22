using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bingo.Data
{
    public class GameContext : DbContext
    {
        public GameContext() : base("GameContext")
        {
        }

        //TODO
        //public DbSet
    }
}