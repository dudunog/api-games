using Game.Domain.Entities;

namespace Game.Domain.Interfaces.Response
{
    public class SaveGameResultResponse : BaseResponse
    {
        public GameResult GameResult { get; set; }
    }
}
