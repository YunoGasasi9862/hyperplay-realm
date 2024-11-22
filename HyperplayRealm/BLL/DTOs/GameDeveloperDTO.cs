using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;


namespace BLL.DTOs
{
    public class GameDeveloperDTO
    {
        public int GameId { get; set; }

        public int DeveloperId { get; set; }

        [Required]
        public required Developer Developer { get; set; }

        [Required]
        public required Game Game { get; set; }

        public static Expression<Func<GameDeveloper, GameDeveloper>> FromEntity => entity => new GameDeveloper
        {
            GameId = entity.GameId,
            DeveloperId = entity.DeveloperId,
            Developer = entity.Developer,
            Game = entity.Game,
        };

        public GameDeveloper MapTo()
        {
            return new GameDeveloper { GameId = GameId, DeveloperId = DeveloperId };
        }
    }
}
