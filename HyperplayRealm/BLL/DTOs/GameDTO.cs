using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel;
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

        public string Genres => string.Join("<br>", MapTo().GameGenres?.Select(ps => ps.Genre?.GenreName));

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

        [DisplayName("Genres")]
        public List<int> GenreIds {
            
            get => MapTo().GameGenres?.Select(gg => gg.GenreId).ToList();
            
            set => MapTo().GameGenres = value.Select(v => new GameGenre() { GenreId = v }).ToList();
        
        }

    }
}
