using Game.Domain.Entities;
using System.Collections.Generic;

namespace Game.Domain.Interfaces.Response
{
    public class GetPlayersResponse : BaseResponse
    {
        public List<Player> Players { get; set; }
    }
}
