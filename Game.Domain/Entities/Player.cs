using EntityFrameworkCore.Triggers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Game.Domain.Entities
{
    public class Player
    {
        [Key]
        public long PlayerId { get; set; }

        [JsonIgnore]
        public string Name { get; set; }

        public long Balance { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public void UpdateBalance(long newBalance)
        {
            this.Balance += newBalance;
        }

        static Player()
        {
            Triggers<Player>.Inserting += entry => entry.Entity.LastUpdateDate = DateTime.Now;
            Triggers<Player>.Updating += entry => entry.Entity.LastUpdateDate = DateTime.Now;
        }
    }
}
