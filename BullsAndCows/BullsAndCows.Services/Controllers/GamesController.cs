namespace BullsAndCows.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using BullsAndCows.Data;
    using BullsAndCows.Data.Contracts;
    using BullsAndCows.GameLogic;
    using BullsAndCows.Models;
    using BullsAndCows.Services.DataModels;
    using BullsAndCows.Services.Infrastructure;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GamesController : BaseApiController
    {
        private readonly IGameDataValidator gameValidator;
        private readonly IUserIdProvider userIdProvider;

        public GamesController()
            : this(new BullsAndCowsData(), new GameDataValidator(), new AspUserIdProvider())
        {
        }

        public GamesController(
            IBullsAndCowsData data,
            IGameDataValidator gameValidator,
            IUserIdProvider userIdProvider)
            : base(data)
        {
            this.gameValidator = gameValidator;
            this.userIdProvider = userIdProvider;
        }

        [HttpPost]
        public IHttpActionResult Create(CreateRequestDataModel request)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var newGame = new Game
            {
                Name = request.GameName,
                FirstPlayerId = currentUserId,
                FirstPlayerSecretNumber = request.FirstPlayerSecretNumber
            };

            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();

            return this.Ok(newGame.Id);
        }

        [HttpPost]
        public IHttpActionResult Join(int secondPlayerSecretNumber)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            if (currentUserId == null)
            {
                return this.BadRequest("Invalid Id. Use token for authorization");
            }

            var game = this.Data.Games
                .All()
                .Where(g => g.State == GameState.WaitingForPlayer && g.FirstPlayerId != currentUserId)
                .FirstOrDefault();

            if (game == null)
            {
                return this.NotFound();
            }

            game.SecondPlayerId = currentUserId;
            game.SecondPlayerSecretNumber = secondPlayerSecretNumber;
            game.State = GameState.FirstPlayerTurn;
            this.Data.SaveChanges();

            return this.Ok(game.Id);
        }

        [HttpGet]
        public IHttpActionResult Status(int gameId)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var game = this.Data.Games.All()
                .Where(x => x.Id == gameId)
                .Select(x => new { x.FirstPlayerId, x.SecondPlayerId })
                .FirstOrDefault();

            if (game == null)
            {
                return this.NotFound();
            }

            if (game.FirstPlayerId != currentUserId &&
                game.SecondPlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            var gameInfo = this.Data.Games.All()
                .Where(g => g.Id == gameId)
                .Select(g => new GameModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    GameStart = g.GameStart,
                    GameEnd = g.GameEnd,
                    State = g.State
                })
                .FirstOrDefault();

            return this.Ok(gameInfo);
        }

        [HttpPost]
        public IHttpActionResult Play(PlayRequestDataModel request)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            if (request == null || !ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var gameId = request.GameId;

            var game = this.Data.Games.SearchFor(g => g.Id == gameId).FirstOrDefault();

            if (game == null)
            {
                return this.BadRequest("Invalid game id!");
            }

            if (game.FirstPlayerId != currentUserId &&
                game.SecondPlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            if (game.State != GameState.FirstPlayerTurn &&
                game.State != GameState.SecondPlayerTurn)
            {
                return this.BadRequest("Invalid game state!");
            }

            if ((game.State == GameState.FirstPlayerTurn &&
                game.FirstPlayerId != currentUserId)
                ||
                (game.State == GameState.SecondPlayerTurn &&
                game.SecondPlayerId != currentUserId))
            {
                return this.BadRequest("It's not your turn!");
            }

            // Update games state and adding new guess number
            var guessNumber = request.GuessNumber;

            var newGuessNumber = new GuessNumber
            {
                Number = guessNumber,
                GameId = gameId,
                PlayerId = currentUserId
            };

            this.Data.GuessNumbers.Add(newGuessNumber);

            game.State = game.State == GameState.FirstPlayerTurn ?
                GameState.SecondPlayerTurn : GameState.FirstPlayerTurn;

            this.Data.SaveChanges();
            var guess = new Guess
            {
                GuessingUserId = currentUserId,
                GuessNumber = guessNumber.ToString()
            };
            var guessResult = this.gameValidator.GetResult(guess, Data);

            switch (guessResult.GameResult)
            {
                case GameResult.NotFinished:
                    break;
                case GameResult.WonByFirstPlayer:
                    game.State = GameState.WonByFirstPlayer;
                    game.GameEnd = DateTime.Now;
                    this.Data.SaveChanges();
                    break;
                case GameResult.WonBySecondPlayer:
                    game.State = GameState.WonBySecondPlayer;
                    game.GameEnd = DateTime.Now;
                    this.Data.SaveChanges();
                    break;
                default:
                    break;
            }

            return this.Ok(guessResult);
        }

        [HttpPost]
        public IHttpActionResult Leave()
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var game = this.Data.Games.All()
                .FirstOrDefault(x => (x.FirstPlayerId == currentUserId || x.SecondPlayerId == currentUserId) &&
                x.State == GameState.FirstPlayerTurn || x.State == GameState.SecondPlayerTurn);

            if (game == null)
            {
                return this.BadRequest("Invalid game id!");
            }

            if (game.FirstPlayerId != currentUserId &&
                game.SecondPlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            if (game.State != GameState.FirstPlayerTurn &&
                game.State != GameState.SecondPlayerTurn)
            {
                return this.BadRequest("Invalid game state!");
            }

            if (currentUserId == game.FirstPlayerId)
            {
                game.State = GameState.WonBySecondPlayer;
            }
            else if (currentUserId == game.SecondPlayerId)
            {
                game.State = GameState.WonByFirstPlayer;
            }

            this.Data.SaveChanges();

            var result = new
            {
                GameId = game.Id,
                GameState = game.State
            };

            return this.Ok(result);
        }
    }
}