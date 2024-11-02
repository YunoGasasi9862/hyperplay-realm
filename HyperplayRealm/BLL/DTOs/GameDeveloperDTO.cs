using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;


namespace BLL.DTOs
{
    public class GameDeveloperDTO : IMapper<GameDeveloper>
    {
        public int GameId { get; set; }

        public int DeveloperId { get; set; }

        [Required]
        public required Developer Developer { get; set; }

        [Required]
        public required Game Game { get; set; }

        public void MapFrom(GameDeveloper entity)
        {
            GameId = entity.GameId;

            DeveloperId = entity.DeveloperId;

            Developer = entity.Developer;

            Game = entity.Game; 
        }
    }
}
