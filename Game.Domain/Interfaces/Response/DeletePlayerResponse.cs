using System.Text.Json.Serialization;

namespace Game.Domain.Interfaces.Response
{
    public class DeletePlayerResponse : BaseResponse
    {
        [JsonIgnore]
        public long PlayerId { get; set; }
    }
}
