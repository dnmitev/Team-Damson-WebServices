namespace BullsAndCows.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Data.Contracts;
    using BullsAndCows.GameLogic;
    using BullsAndCows.Services.Infrastructure;
    using BullsAndCows.Services.DataModels;

    public class GamesController : BaseApiController
    {
        private readonly IGameDataValidator gameValidator;
        private readonly IUserIdProvider userIdProvider;

        public GamesController()
            : this(new BullsAndCowsData())
        {
        }

        //public GamesController(
        //    IBullsAndCowsData data,
        //    IGameDataValidator gamaValidator,
        //    IUserIdProvider userIdProvider) : base(data)
        //{
        //    this.gameValidator = gameValidator;
        //    this.userIdProvider = userIdProvider;
        //}

        public GamesController(IBullsAndCowsData data):base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Create(GameModel game)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGame = new Game
            {
                Name = game.Name,
                GameStart = game.GameStart
            };

            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();

            return Ok(newGame.Id);
        }
    }
}