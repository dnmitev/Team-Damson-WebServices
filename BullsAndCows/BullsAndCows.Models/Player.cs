namespace BullsAndCows.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class Player : IdentityUser
    {
        private ICollection<GuessNumber> guessNumbers;

        public Player()
        {
            this.GuessNumbers = new HashSet<GuessNumber>();
        }
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Player> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<GuessNumber> GuessNumbers
        {
            get
            {
                return this.guessNumbers;
            }
            set
            {
                this.guessNumbers = value;
            }
        }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Range(1000, 9999)]
        public int NumberToGuess { get; set; }
    }
}