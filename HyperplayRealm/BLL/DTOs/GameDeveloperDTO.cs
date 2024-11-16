using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;


namespace BLL.DTOs
{
    public class GameDeveloperDTO : IMapper<GameDeveloper, GameDeveloperDTO>
    {
        public int GameId { get; set; }

        public int DeveloperId { get; set; }

        [Required]
        public required Developer Developer { get; set; }

        [Required]
        public required Game Game { get; set; }

        public GameDeveloperDTO MapFrom(GameDeveloper entity)
        {
            GameId = entity.GameId;

            DeveloperId = entity.DeveloperId;

            Developer = entity.Developer;

            Game = entity.Game;

            return this;
        }

        public GameDeveloper MapTo()
        {
            return new GameDeveloper { GameId = GameId, DeveloperId = DeveloperId };
        }
    }
}
