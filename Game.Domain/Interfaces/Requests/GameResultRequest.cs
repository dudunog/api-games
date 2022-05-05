using System;

namespace Game.Domain.Interfaces.Requests
{
    public class GameResultRequest
    {
        public long PlayerId { get; set; }

        public long GameId { get; set; }

        public long Win { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
