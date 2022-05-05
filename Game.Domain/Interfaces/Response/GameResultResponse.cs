using System;

namespace Game.Domain.Interfaces.Response
{
    public class GameResultResponse
    {
        public long Id { get; set; }

        public long PlayerId { get; set; }

        public long GameId { get; set; }

        public long Win { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
