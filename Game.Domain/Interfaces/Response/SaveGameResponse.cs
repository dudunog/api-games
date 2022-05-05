namespace Game.Domain.Interfaces.Response
{
    public class SaveGameResponse : BaseResponse
    {
        public Game.Domain.Entities.Game Game { get; set; }
    }
}
