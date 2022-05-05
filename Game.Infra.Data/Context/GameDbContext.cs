using EntityFrameworkCore.Triggers;
using Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Game.Infra.Data.Context
{
    public class GameDbContext : DbContextWithTriggers
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game.Domain.Entities.Game> Games { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
    }
}
