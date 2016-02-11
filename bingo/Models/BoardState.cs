using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class BoardState
    {
        //public List<Cell> Cells { get; set; }

        /// <summary>
        /// Game board layout
        /// </summary>
        public Cell[,] Cells { get; set; }

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

        public BoardState (int width, int height)
        {
            Cells = new Cell[width, height];
        }
    }
}