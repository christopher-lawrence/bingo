using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bingo.Models
{
    public class GameState
    {
        public Guid Id { get; set; }
        public State CurrentState { get; set; }

        // Foreign Keys
        public Guid GameId { get; set; }

        // Navigations
        public virtual Game Game { get; set; }

        //TODO: Winner can be determined via GameCardStates...
        public Guid? WinnerId { get; set; }
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