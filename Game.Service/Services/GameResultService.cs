using System;
using System.Linq;
using Game.Domain.Entities;
using Game.Domain.Interfaces;
using Game.Domain.Interfaces.Response;
using Game.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Service.Services
{
    public class GameResultService : IGameResultService
    {
        private readonly GameDbContext gameDbContext;

        public GameResultService(GameDbContext gameDbContext)
        {
            this.gameDbContext = gameDbContext;
        }

        public async Task<GetGameResultResponse> GetGameResults()
        {
            IEnumerable<GameResult> gameResults = await gameDbContext.GameResults.ToListAsync();

            if (gameResults.Count() == 0)
            {
                return new GetGameResultResponse
                {
                    Success = false,
                    Error = "No game results found"
                };
            }

            return new GetGameResultResponse { Success = true, GameResults = gameResults.ToList() };
        }

        public async Task<SaveGameResultResponse> SaveGameResult(GameResult gameResult)
        {
            Game.Domain.Entities.Game game = await gameDbContext.Games.FindAsync(gameResult.GameId);
            Player player = await gameDbContext.Players.FindAsync(gameResult.PlayerId);

            if (game == null)
            {
                return new SaveGameResultResponse
                {
                    Success = false,
                    Error = "This game doesn't exist"
                };
            }

            if (player == null)
            {
                return new SaveGameResultResponse
                {
                    Success = false,
                    Error = "This player doesn't exist"
                };
            }

            player.UpdateBalance(gameResult.Win);
            player.LastUpdateDate = DateTime.Now;
            gameDbContext.Entry(player).State = EntityState.Modified;

            await gameDbContext.GameResults.AddAsync(gameResult);

            int saveResponse = await gameDbContext.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new SaveGameResultResponse
                {
                    Success = true,
                    GameResult = gameResult
                };
            }

            return new SaveGameResultResponse
            {
                Success = false,
                Error = "Unable to save game result"
            };
        }
    }
}
