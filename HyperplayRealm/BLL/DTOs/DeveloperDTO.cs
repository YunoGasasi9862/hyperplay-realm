using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BLL.Interfaces;
using BLL.Models;

namespace BLL.DTOs
{
    public class DeveloperDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public DeveloperDTO MapFrom(Developer entity)
        {
            Id = entity.Id;

            Name = entity.Name;

            return this;
        }

        public static Expression<Func<Developer, DeveloperDTO>> FromEntity => entity => new DeveloperDTO
        {
            Id = entity.Id,
            Name = entity.Name,
        };

        public Developer MapTo()
        {
            return new Developer() { Id = Id, Name = Name };
        }
    }
}
