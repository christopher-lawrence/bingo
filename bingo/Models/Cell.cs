using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class Cell
    {
        public Guid Id { get; set; }
        public bool Marked { get; set; }

        public Guid CellContentId { get; set; }
        public CellContent CellContent { get; set; }
        
        
        //TODO: X,Y Position?
    }
}