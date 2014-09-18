namespace BullsAndCows.Services.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    using BullsAndCows.Models;
    
    public class GameModel
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public DateTime GameStart { get; set; }

        public DateTime? GameEnd { get; set; }

        public GameState State { get; set; }
    }
}