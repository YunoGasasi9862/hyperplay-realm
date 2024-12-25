using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

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

        public string? GameLogo { get; set; }

        public List<string>? Genres { get; set;}

        public List<string>? Developers { get; set; }
        public string? GenreList => Genres != null && Genres.Any() ? string.Join(", ", Genres) : string.Empty;
        public string? DeveloperList => Developers != null && Developers.Any() ? string.Join(", ", Developers) : string.Empty;
        public static Expression<Func<Game, GameDTO>> FromEntity => entity => new GameDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            Price = entity.Price,
            Quantity = entity.Quantity,
            PublisherId = entity.PublisherId,
            ReleaseDate = entity.ReleaseDate,
            PublisherName = entity.Publisher.Name,
            Genres = entity.GameGenres.Where(gg => gg.GenreId == gg.Genre.Id).Select(gg => gg.Genre.GenreName).ToList(),
            Developers = entity.GameDevelopers.Where(developer => developer.DeveloperId == developer.Developer.Id).Select(developer => developer.Developer.Name).ToList()
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

        [DisplayName("Developers")]
        public List<int> DeveloperIds
        {

            get => MapTo().GameDevelopers?.Select(gd => gd.DeveloperId).ToList();

            set => MapTo().GameDevelopers = value.Select(v => new GameDeveloper() { DeveloperId = v }).ToList();
        }


    }
}
