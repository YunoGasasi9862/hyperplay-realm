using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BLL.DTOs
{
    public class GameGenreDTO 
    {
        public int GameId { get; set; }

        public int GenreId { get; set; }

        [Required]
        public required Game Game { get; set; }

        [Required]
        public required Genre Genre { get; set; }

        public static Expression<Func<GameGenre, GameGenreDTO>> FromEntity => entity => new GameGenreDTO
        {
            GameId = entity.GameId,
            GenreId = entity.GenreId,
            Game = entity.Game,
            Genre = entity.Genre
        };

        public GameGenre MapTo()
        {
            return new GameGenre() { GameId = GameId, GenreId = GenreId };
        }
    }
}
