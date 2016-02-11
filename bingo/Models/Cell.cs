using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class Cell
    {
        public CellContent Content { get; set; }
        
        public bool Marked { get; set; }
        
        //TODO: X,Y Position?
    }
}