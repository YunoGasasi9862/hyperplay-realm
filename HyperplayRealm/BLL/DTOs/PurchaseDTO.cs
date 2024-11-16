using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class PurchaseDTO : IMapper<Purchase, PurchaseDTO>
    {
        public int UserId { get; set; }

        public int GameId { get; set; }

        public DateTime PurchaseDate { get; set; }

        [Required]
        public required Game Game { get; set; }

        [Required]
        public required User User { get; set; }
        public PurchaseDTO MapFrom(Purchase entity)
        {
            UserId = entity.UserId;

            GameId = entity.GameId;

            PurchaseDate = entity.PurchaseDate; 

            Game = entity.Game; 

            User = entity.User;

            return this;
        }

        public Purchase MapTo()
        {
           return new Purchase { UserId = UserId, GameId = GameId, PurchaseDate = PurchaseDate };
        }
    }
}
