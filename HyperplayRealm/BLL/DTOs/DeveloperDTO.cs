using System;
using System.ComponentModel.DataAnnotations;
using BLL.Interfaces;
using BLL.Models;

namespace BLL.DTOs
{
    public class DeveloperDTO: IMapper<Developer, DeveloperDTO>
    {
        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public required string Name { get; set; }

        public DeveloperDTO MapFrom(Developer entity)
        {
            DeveloperId = entity.DeveloperId;

            Name = entity.Name;

            return this;
        }

        public Developer MapTo()
        {
            return new Developer() { DeveloperId = this.DeveloperId, Name = this.Name };
        }
    }
}
