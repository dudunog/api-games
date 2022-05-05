using System.Text.Json.Serialization;

namespace Game.Domain.Interfaces.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }

        public string Error { get; set; }
    }
}
