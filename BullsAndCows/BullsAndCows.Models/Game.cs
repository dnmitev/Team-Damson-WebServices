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
        public Game()
        {
            this.State = GameState.WaitingForPlayer;
            this.GameStart = DateTime.Now;
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public DateTime GameStart { get; set; }

        public DateTime? GameEnd { get; set; }

        public GameState State { get; set; }

        public string FirstPlayerId { get; set; }

        [Range(1000, 9999)]
        public int FirstPlayerSecretNumber { get; set; }

        public virtual Player FirstPlayer { get; set; }

        public string SecondPlayerId { get; set; }

        [Range(1000, 9999)]
        public int? SecondPlayerSecretNumber { get; set; }

        public virtual Player SecondPlayer { get; set; }
    }
}