using Game.Domain.Interfaces;
using Game.Domain.Interfaces.Requests;
using Game.Domain.Interfaces.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Game.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        [Route("get_games")]
        public async Task<IActionResult> Get()
        {
            GetGamesResponse getGamesResponse = await gameService.GetGames();

            if (!getGamesResponse.Success)
            {
                return UnprocessableEntity(getGamesResponse);
            }

            return Ok(getGamesResponse);
        }

        [HttpPost]
        [Route("save_game")]
        public async Task<IActionResult> Post(GameRequest gameRequest)
        {
            Game.Domain.Entities.Game game = new Game.Domain.Entities.Game
            {
                Name = gameRequest.Name,
            };

            SaveGameResponse saveGameResponse = await gameService.SaveGame(game);

            if (!saveGameResponse.Success)
            {
                return UnprocessableEntity(saveGameResponse);
            }

            GameResponse gameResultResponse = new GameResponse
            {
                Success = true,
                Game = saveGameResponse.Game
            };

            return Ok(gameResultResponse);
        }
    }
}
