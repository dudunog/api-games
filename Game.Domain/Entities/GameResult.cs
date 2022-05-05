using System;

namespace Game.Domain.Entities
{
    public class GameResult
    {
        public long Id { get; set; }

        public long PlayerId { get; set; }

        public long GameId { get; set; }

        public long Win { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual Player Player { get; set; }

        public virtual Game Game { get; set; }
    }
}
