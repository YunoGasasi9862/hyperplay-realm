using BLL.Interfaces;
using BLL.Models;
namespace BLL.DTOs
{
    public class UserDTO : IMapper<User>
    {
        public void MapFrom(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
