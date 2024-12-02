using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    //so since im using LoadResult, you'll use Service - just like in the assignments
    public class UsersServiceImpl : LoadResult, IDBOperations<User, UserDTO>
    {
        public UsersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {

        }

        public Task<LoadResult> Create(User type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDTO> Query()
        {
            return HyperplayRealmDBContext.Users.Select(UserDTO.FromEntity);
        }

        public Task<LoadResult> Update(User type)
        {
            throw new NotImplementedException();
        }
    }
}
