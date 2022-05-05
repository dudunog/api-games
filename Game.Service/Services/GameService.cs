using System.Linq;
using Game.Domain.Interfaces;
using Game.Domain.Interfaces.Response;
using Game.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Service.Services
{
    public class GameService : IGameService
    {
        private readonly GameDbContext gameDbContext;

        public GameService(GameDbContext gameDbContext)
        {
            this.gameDbContext = gameDbContext;
        }

        public async Task<GetGamesResponse> GetGames()
        {
            IEnumerable<Game.Domain.Entities.Game> games = await gameDbContext.Games.ToListAsync();

            if (games.Count() == 0)
            {
                return new GetGamesResponse
                {
                    Success = false,
                    Error = "No games found"
                };
            }

            return new GetGamesResponse { Success = true, Games = games.ToList() };
        }

        public async Task<SaveGameResponse> SaveGame(Game.Domain.Entities.Game game)
        {
            await gameDbContext.Games.AddAsync(game);

            int saveResponse = await gameDbContext.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new SaveGameResponse
                {
                    Success = true,
                    Game = game
                };
            }

            return new SaveGameResponse
            {
                Success = false,
                Error = "Unable to save game"
            };
        }
    }
}
