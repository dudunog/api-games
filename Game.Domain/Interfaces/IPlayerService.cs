using Game.Domain.Entities;
using Game.Domain.Interfaces.Response;
using System.Threading.Tasks;

namespace Game.Domain.Interfaces
{
    public interface IPlayerService
    {
        Task<GetPlayersResponse> GetPlayers();
        Task<SavePlayerResponse> SavePlayer(Player player);
    }
}
