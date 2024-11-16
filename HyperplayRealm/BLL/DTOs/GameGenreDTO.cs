using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class GameGenreDTO : IMapper<GameGenre, GameGenreDTO>
    {
        public int GameId { get; set; }

        public int GenreId { get; set; }

        [Required]
        public required Game Game { get; set; }

        [Required]
        public required Genre Genre { get; set; }

        public GameGenreDTO MapFrom(GameGenre entity)
        {
            GameId = entity.GameId;

            GenreId = entity.GenreId;   

            Game = entity.Game;

            Genre = entity.Genre;   

            return this;
        }

        public GameGenre MapTo()
        {
            return new GameGenre() { GameId = GameId, GenreId = GenreId };
        }
    }
}
