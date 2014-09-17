namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Game
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public DateTime GameStart { get; set; }

        public DateTime GameEnd { get; set; }

        public GameState State { get; set; }

        [Required]
        public string FirstPlayerId { get; set; }

        public virtual Player FirstPlayer { get; set; }

        public virtual Player SecondPlayer { get; set; }
    }
}