using Game.Domain.Entities;
using Game.Domain.Interfaces;
using Game.Domain.Interfaces.Response;
using Game.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Service.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly GameDbContext gameDbContext;

        public PlayerService(GameDbContext gameDbContext)
        {
            this.gameDbContext = gameDbContext;
        }

        public async Task<GetPlayersResponse> GetPlayers()
        {
            IEnumerable<Player> players = await gameDbContext.Players.OrderByDescending(p => p.Balance).ToListAsync();

            if (players.Count() == 0)
            {
                return new GetPlayersResponse
                {
                    Success = false,
                    Error = "No players found"
                };
            }

            return new GetPlayersResponse { Success = true, Players = players.ToList() };
        }

        public async Task<SavePlayerResponse> SavePlayer(Player player)
        {
            await gameDbContext.Players.AddAsync(player);

            int saveResponse = await gameDbContext.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new SavePlayerResponse
                {
                    Success = true,
                    Player = player
                };
            }

            return new SavePlayerResponse
            {
                Success = false,
                Error = "Unable to save player"
            };
        }
    }
}
