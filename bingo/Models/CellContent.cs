using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bingo.Models
{
    public class CellContent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        // TODO: Image

        // ForeignKeys
        public Guid AccountId { get; set; }

        // Relations
        public Account Account { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<GameCard> GameCards { get; set; }

        public CellContent()
        {
            Id = Guid.NewGuid();
            Title = "New Cell Content";
        }
    }
}