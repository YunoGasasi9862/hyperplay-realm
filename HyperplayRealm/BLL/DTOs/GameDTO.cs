using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;


namespace BLL.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int PublisherId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? PublisherName { get; set; }

        public static Expression<Func<Game, GameDTO>> FromEntity => entity => new GameDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            Price = entity.Price,
            Quantity = entity.Quantity,
            PublisherId = entity.PublisherId,
            ReleaseDate = entity.ReleaseDate,
            PublisherName = entity.Publisher.Name,
        };

        public Game MapTo()
        {
            return new Game { Id = Id, Title = Title, Price = Price, Quantity = Quantity, PublisherId = PublisherId, ReleaseDate = ReleaseDate };
        }
    }
}
