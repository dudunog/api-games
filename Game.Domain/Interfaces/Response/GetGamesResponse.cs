using System.Collections.Generic;

namespace Game.Domain.Interfaces.Response
{
    public class GetGamesResponse : BaseResponse
    {
        public List<Game.Domain.Entities.Game> Games { get; set; }
    }
}
