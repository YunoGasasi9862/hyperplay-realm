using BLL.Interfaces;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
namespace BLL.DTOs
{
    public class UserDTO : IMapper<User>
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Username { get; set; }


        public string? Surname { get; set; }

        [Required]
        public required string Email { get; set; }

        //Hash it
        [Required]
        public required string Password { get; set; }

        public string? ProfilePicturePath { get; set; }

        public bool RememberMe { get; set; }

        public void MapFrom(User entity)
        {
            Id = entity.Id;

            Name = entity.Name;

            Username = entity.Username;

            Surname = entity.Surname;

            Email = entity.Email;

            Password = entity.Password;

            ProfilePicturePath = entity.ProfilePicturePath;
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

    }
}
