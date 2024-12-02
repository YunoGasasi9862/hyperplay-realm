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

        public string? DeveloperName { get; set; }

        public string? GameName { get; set; }

        public static Expression<Func<GameDeveloper, GameDeveloperDTO>> FromEntity => entity => new GameDeveloperDTO
        {
            GameId = entity.GameId,
            DeveloperId = entity.DeveloperId,
            DeveloperName = entity.Developer.Name,
            GameName = entity.Game.Title,
        };

        public GameDeveloper MapTo()
        {
            return new GameDeveloper { GameId = GameId, DeveloperId = DeveloperId };
        }
    }
}
