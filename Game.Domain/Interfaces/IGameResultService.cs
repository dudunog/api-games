using Game.Domain.Entities;
using Game.Domain.Interfaces.Response;
using System.Threading.Tasks;

namespace Game.Domain.Interfaces
{
    public interface IGameResultService
    {
        Task<GetGameResultResponse> GetGameResults();
        Task<SaveGameResultResponse> SaveGameResult(GameResult gameResult);
    }
}
