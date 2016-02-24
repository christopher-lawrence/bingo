using System;
using System.ComponentModel.DataAnnotations;

namespace bingo.Models
{
    public class CellContent
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        // TODO: Image

        public CellContent()
        {
            Id = Guid.NewGuid();
            Title = "New Cell Content";
        }
    }
}