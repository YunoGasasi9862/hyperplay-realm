using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;


namespace BLL.DTOs
{
    public class GameDTO : IMapper<Game>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int PublisherId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Publisher? Publisher { get; set; }

        public void MapFrom(Game entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Price = entity.Price;
            Quantity = entity.Quantity;
            PublisherId = entity.PublisherId;
            ReleaseDate = entity.ReleaseDate;
            Publisher = entity.Publisher;
        }

        public Game MapTo()
        {
            throw new NotImplementedException();
        }
    }
}
