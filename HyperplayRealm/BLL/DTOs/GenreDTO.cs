using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class GenreDTO : IMapper<Genre>
    {
        public int Id { get; set; }

        [Required]
        public required string GenreName { get; set; }

        public void MapFrom(Genre entity)
        {
            Id = entity.Id;

            GenreName = entity.GenreName;
        }
    }
}
