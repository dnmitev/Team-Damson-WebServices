namespace BullsAndCows.Services.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class PlayRequestDataModel
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int GuessNumber { get; set; }
    }
}