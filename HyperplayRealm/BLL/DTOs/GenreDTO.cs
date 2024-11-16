using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class GenreDTO : IMapper<Genre, GenreDTO>
    {
        public int Id { get; set; }

        [Required]
        public required string GenreName { get; set; }

        public GenreDTO MapFrom(Genre entity)
        {
            Id = entity.Id;

            GenreName = entity.GenreName;

            return this;
        }

        public Genre MapTo()
        {
            return new Genre { Id = Id, GenreName = GenreName };
        }
    }
}
