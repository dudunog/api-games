using Game.Domain.Entities;
using Game.Domain.Interfaces;
using Game.Domain.Interfaces.Requests;
using Game.Domain.Interfaces.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameResultController : ControllerBase
    {
        private readonly IGameResultService gameResultService;

        public GameResultController(IGameResultService gameResultService)
        {
            this.gameResultService = gameResultService;
        }

        [HttpGet]
        [Route("get_game_results")]
        public async Task<IActionResult> Get()
        {
            GetGameResultResponse getGameResultResponse = await gameResultService.GetGameResults();

            if (!getGameResultResponse.Success)
            {
                return UnprocessableEntity(getGameResultResponse);
            }

            IEnumerable<GameResultResponse> gameResultResponse = getGameResultResponse.GameResults.ConvertAll(o =>
                new GameResultResponse { Id = o.Id, GameId = o.GameId, PlayerId = o.PlayerId, Timestamp = o.Timestamp, Win = o.Win });

            return Ok(gameResultResponse);
        }

        [HttpPost]
        [Route("save_game_result")]
        public async Task<IActionResult> Post(GameResultRequest gameResultRequest)
        {
            GameResult gameResult = new GameResult
            {
                PlayerId = gameResultRequest.PlayerId,
                GameId = gameResultRequest.GameId,
                Win = gameResultRequest.Win,
                Timestamp = gameResultRequest.Timestamp
            };

            SaveGameResultResponse saveGameResultResponse = await gameResultService.SaveGameResult(gameResult);

            if (!saveGameResultResponse.Success)
            {
                return UnprocessableEntity(saveGameResultResponse);
            }

            GameResultResponse gameResultResponse = new GameResultResponse
            {
                Id = saveGameResultResponse.GameResult.Id,
                PlayerId = saveGameResultResponse.GameResult.PlayerId,
                GameId = saveGameResultResponse.GameResult.GameId,
                Win = saveGameResultResponse.GameResult.Win,
                Timestamp = saveGameResultResponse.GameResult.Timestamp,
            };

            return Ok(gameResultResponse);
        }
    }
}
