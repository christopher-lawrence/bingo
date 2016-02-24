using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class GameCardState
    {
        // Properties
        // ??        
        public Cell[,] Cells { get; set; }
        public GameState.State GameState { get; set; }

        // Relations
        [Key, ForeignKey("GameCard")]
        public Guid GameCardId { get; set; }
        public virtual GameCard GameCard { get; set; }

        #region Winning States
        private char[,] _winningStates = new char[,] {
            { '*', '*', '*', '*', '*' ,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty },
            { Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              '*', '*', '*', '*', '*' ,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
            },
            { Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              '*', '*', '*', '*', '*' ,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
            },
            { Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              '*', '*', '*', '*', '*' ,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
            },
            { Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              '*', '*', '*', '*', '*' ,
            },
            { '*', Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              '*', Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              '*', Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              '*', Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              '*', Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
            },
            { Constants.Empty, '*', Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, '*', Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, '*', Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, '*', Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, '*', Constants.Empty, Constants.Empty, Constants.Empty,
            },
            { Constants.Empty, Constants.Empty, '*', Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, '*', Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, '*', Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, '*', Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, '*', Constants.Empty, Constants.Empty,
            },
            { Constants.Empty, Constants.Empty, Constants.Empty, '*', Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, '*', Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, '*', Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, '*', Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, '*', Constants.Empty,
            },
            { Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, '*',
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, '*',
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, '*',
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, '*',
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, '*',
            },
            { '*', Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty,'*', Constants.Empty, Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, '*', Constants.Empty, Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty,'*', Constants.Empty,
              Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, '*',
            },
            { Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty, '*',
              Constants.Empty, Constants.Empty, Constants.Empty, '*', Constants.Empty,
              Constants.Empty, Constants.Empty, '*', Constants.Empty, Constants.Empty,
              Constants.Empty, '*', Constants.Empty, Constants.Empty, Constants.Empty,
              '*', Constants.Empty, Constants.Empty, Constants.Empty, Constants.Empty,
            },
        };
        #endregion

        public GameCardState (int width, int height)
        {
            Cells = new Cell[width, height];
        }
    }
}