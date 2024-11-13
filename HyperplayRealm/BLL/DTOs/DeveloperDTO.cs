using System;
using System.ComponentModel.DataAnnotations;
using BLL.Interfaces;
using BLL.Models;

namespace BLL.DTOs
{
    public class DeveloperDTO: IMapper<Developer>
    {
        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public required string Name { get; set; }

        public void MapFrom(Developer entity)
        {
            DeveloperId = entity.DeveloperId;

            Name = entity.Name;
        }

        public Developer MapTo()
        {
            throw new NotImplementedException();
        }
    }
}
