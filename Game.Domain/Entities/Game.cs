using System.ComponentModel.DataAnnotations;

namespace Game.Domain.Entities
{
    public class Game
    {
        [Key]
        public long GameId { get; set; }

        public string Name { get; set; }
    }
}
