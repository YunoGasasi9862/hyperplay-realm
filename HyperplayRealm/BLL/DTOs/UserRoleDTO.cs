using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserRoleDTO : IMapper<UserRole>
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        [Required]
        public required Role Role { get; set; }

        [Required]
        public required User User { get; set; }

        public void MapFrom(UserRole entity)
        {
            UserId = entity.UserId;

            RoleId = entity.RoleId;

            Role = entity.Role;

            User = entity.User; 
        }
    }
}
