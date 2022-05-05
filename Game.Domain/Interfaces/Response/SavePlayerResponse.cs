using Game.Domain.Entities;

namespace Game.Domain.Interfaces.Response
{
    public class SavePlayerResponse : BaseResponse
    {
        public Player Player { get; set; }
    }
}
