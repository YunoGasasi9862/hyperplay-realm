using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class RoleDTO : IMapper<Role>
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }
        public void MapFrom(Role entity)
        {
            Id = entity.Id;

            Name = entity.Name;

            Description = entity.Description;   
        }
    }
}
