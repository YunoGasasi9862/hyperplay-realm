using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BLL.DTOs
{
    public class PurchaseDTO
    {
        public int UserId { get; set; }

        public int GameId { get; set; }

        public DateTime PurchaseDate { get; set; }

        [Required]
        public required Game Game { get; set; }

        [Required]
        public required User User { get; set; }

        public static Expression<Func<Purchase, PurchaseDTO>> FromEntity => entity => new PurchaseDTO
        {
            UserId = entity.UserId,
            GameId = entity.GameId,
            PurchaseDate = entity.PurchaseDate,
            Game = entity.Game,
            User = entity.User
        };


        public Purchase MapTo()
        {
           return new Purchase { UserId = UserId, GameId = GameId, PurchaseDate = PurchaseDate };
        }
    }
}
