using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Won { get; set; }
    }
}