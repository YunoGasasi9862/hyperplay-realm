using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;


namespace BLL.DTOs
{
    public class GameDTO : IMapper<Game, GameDTO>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int PublisherId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Publisher? Publisher { get; set; }

        public GameDTO MapFrom(Game entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Price = entity.Price;
            Quantity = entity.Quantity;
            PublisherId = entity.PublisherId;
            ReleaseDate = entity.ReleaseDate;
            Publisher = entity.Publisher;
            return this;
        }

        public Game MapTo()
        {
            return new Game { Id = Id, Title = Title, Price = Price, Quantity = Quantity, PublisherId = PublisherId, ReleaseDate = ReleaseDate };  
        }
    }
}
