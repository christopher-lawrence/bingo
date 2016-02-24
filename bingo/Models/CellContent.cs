using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bingo.Models
{
    public class CellContent
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        // TODO: Image

        // Relations
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public virtual ICollection<Game> Game { get; set; }

        public CellContent()
        {
            Id = Guid.NewGuid();
            Title = "New Cell Content";
        }
    }
}