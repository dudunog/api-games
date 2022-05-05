using Game.Domain.Interfaces.Response;
using System.Threading.Tasks;

namespace Game.Domain.Interfaces
{
    public interface IGameService
    {
        Task<GetGamesResponse> GetGames();
        Task<SaveGameResponse> SaveGame(Game.Domain.Entities.Game game);
    }
}
