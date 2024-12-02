using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BLL.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }

        public string? GenreName { get; set; }

        public static Expression<Func<Genre, GenreDTO>> FromEntity => entity => new GenreDTO
        {
            Id = entity.Id,
            GenreName = entity.GenreName
        };


        public Genre MapTo()
        {
            return new Genre { Id = Id, GenreName = GenreName };
        }
    }
}
