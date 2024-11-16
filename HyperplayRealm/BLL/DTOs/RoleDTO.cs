using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class RoleDTO : IMapper<Role, RoleDTO>
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }
        public RoleDTO MapFrom(Role entity)
        {
            Id = entity.Id;

            Name = entity.Name;

            Description = entity.Description;

            return this;
        }

        public Role MapTo()
        {
           return new Role() { Description = Description, Id = Id , Name = Name };    
        }
    }
}
