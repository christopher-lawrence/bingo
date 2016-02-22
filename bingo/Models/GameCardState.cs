using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class GameCardState
    {
        //public List<Cell> Cells { get; set; }

        /// <summary>
        /// Game board layout
        /// </summary>
        public Cell[,] Cells { get; set; }

        public GameState State { get; private set; }

        private char[,] _winingStates = new char[,] {
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

        public GameCardState (int width, int height)
        {
            Cells = new Cell[width, height];
        }
        
        public void SetState(GameState state)
        {
            //??
            State = state;
        }
    }
}