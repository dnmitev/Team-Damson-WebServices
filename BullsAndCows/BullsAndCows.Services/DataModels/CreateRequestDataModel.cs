namespace BullsAndCows.Services.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class CreateRequestDataModel
    {
        [MinLength(3)]
        public string GameName { get; set; }

        [Range(1000, 9999)]
        public int FirstPlayerSecretNumber { get; set; }
    }
}