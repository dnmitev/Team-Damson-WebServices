namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class GuessNumber
    {
        public int Id { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int Number { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public string PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}