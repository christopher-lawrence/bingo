using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<CellContent> CellContents { get; set; }
    }
}