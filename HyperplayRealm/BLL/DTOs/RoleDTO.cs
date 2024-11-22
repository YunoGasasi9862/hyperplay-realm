using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BLL.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        public static Expression<Func<Role, RoleDTO>> FromEntity => entity => new RoleDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description
        };

        public Role MapTo()
        {
           return new Role() { Description = Description, Id = Id , Name = Name };    
        }
    }
}
