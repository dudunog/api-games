using Game.Domain.Entities;
using System.Collections.Generic;

namespace Game.Domain.Interfaces.Response
{
    public class GetGameResultResponse : BaseResponse
    {
        public List<GameResult> GameResults { get; set; }
    }
}
