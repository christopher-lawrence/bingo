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
        public Guid Id { get; set; }
        // ??        
        public Cell[,] Cells { get; set; }

        // ForeignKeys
        public Guid GameCardId { get; set; }

        // Navigation
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