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
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        [Route("get_players")]
        public async Task<IActionResult> Get()
        {
            GetPlayersResponse getPlayersResponse = await playerService.GetPlayers();

            if (!getPlayersResponse.Success)
            {
                return UnprocessableEntity(getPlayersResponse);
            }

            IEnumerable<PlayerResponse> gameResultResponse = getPlayersResponse.Players.ConvertAll(p =>
                new PlayerResponse { Success = true, Player = p });

            return Ok(gameResultResponse);
        }


        [HttpPost]
        [Route("create_player")]
        public async Task<IActionResult> Post(PlayerRequest playerRequest)
        {
            Player player = new Player
            {
                Name = playerRequest.Name
            };

            SavePlayerResponse savePlayerResponse = await playerService.SavePlayer(player);

            if (!savePlayerResponse.Success)
            {
                return UnprocessableEntity(savePlayerResponse);
            }

            PlayerResponse oficinaResponse = new PlayerResponse
            {
                Player = new Player
                {
                    PlayerId = savePlayerResponse.Player.PlayerId,
                    Name = savePlayerResponse.Player.Name,
                    Balance = savePlayerResponse.Player.Balance,
                    LastUpdateDate = savePlayerResponse.Player.LastUpdateDate
                }
            };

            return Ok(oficinaResponse);
        }
    }
}
