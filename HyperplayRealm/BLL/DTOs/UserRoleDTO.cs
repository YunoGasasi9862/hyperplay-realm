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

        public Role Role { get; set; }

        public User User { get; set; }

        public static Expression<Func<UserRole, UserRoleDTO>> FromEntity => entity => new UserRoleDTO
        {
            UserId = entity.UserId,
            RoleId = entity.RoleId
        };


        public UserRole MapTo()
        {
            return new UserRole() { UserId = UserId, RoleId = RoleId };
        }
    }
}
