using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class GameState
    {
        public Guid Id { get; set; }
        public State CurrentState { get; set; }

        public Guid? WinnerId { get; set; }
        public Player Winner { get; set; }
        
        public GameState()
        {
            CurrentState = State.Setup;
            Id = Guid.NewGuid();
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