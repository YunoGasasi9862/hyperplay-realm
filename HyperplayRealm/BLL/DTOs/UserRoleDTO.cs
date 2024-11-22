using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BLL.DTOs
{
    public class UserRoleDTO
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        [Required]
        public required Role Role { get; set; }

        [Required]
        public required User User { get; set; }

        public static Expression<Func<UserRole, UserRoleDTO>> FromEntity => entity => new UserRoleDTO
        {
            UserId = entity.UserId,
            RoleId = entity.RoleId,
            Role = entity.Role,
            User = entity.User
        };


        public UserRole MapTo()
        {
            return new UserRole() { UserId = UserId, RoleId = RoleId };
        }
    }
}
