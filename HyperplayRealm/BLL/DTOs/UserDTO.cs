using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
namespace BLL.DTOs
{
    public class UserDTO : IMapper<User, UserDTO>
    {
        public UserDTO()
        {

        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string? Surname { get; set; }

        public string Email { get; set; }

        //Hash it
        public string Password { get; set; }

        public string? ProfilePicturePath { get; set; }

        public bool RememberMe { get; set; }

        public List<string> Roles { get; set; }

        public UserDTO MapFrom(User entity)
        {
            Id = entity.Id;

            Name = entity.Name;

            Username = entity.Username;

            Surname = entity.Surname;

            Email = entity.Email;

            Password = entity.Password;

            ProfilePicturePath = entity.ProfilePicturePath;

            Roles = GetRoleNames(entity);

            return this;
        }


        public User MapTo()
        {
            return new User
            {
                Id = this.Id,

                Name = this.Name,

                Username = this.Username,

                Surname = this.Surname,

                Email = this.Email,

                Password = this.Password,

                ProfilePicturePath = this.ProfilePicturePath
            };
        }

        private  List<string> GetRoleNames(User entity)
        {
            return entity.UserRoles.Select(role => role.Role.Name).ToList();
        }

    }
}
