using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Domain.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string TokenHash { get; set; }

        [Required]
        [MaxLength(1000)]
        public string TokenSalt { get; set; }

        [Column("TS")]
        public DateTime Ts { get; set; }

        public DateTime ExpiryDate { get; set; }

        public virtual Player Player { get; set; }
    }
}
