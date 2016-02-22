using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class GameState
    {
        public State CurrentState { get; set; }
        public Player Winner { get; set; }

        public GameState()
        {
            CurrentState = State.Setup;
        }

        public enum State
        {
            Setup,
            Session,
            Complete,
            Win,
            Lose,
            Tie // ?
        }

    }
}