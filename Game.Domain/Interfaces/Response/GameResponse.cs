namespace Game.Domain.Interfaces.Response
{
    public class GameResponse : BaseResponse
    {
        public Game.Domain.Entities.Game Game { get; set; }
    }
}
