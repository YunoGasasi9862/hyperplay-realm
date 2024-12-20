using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;
using BLL.Enums;

namespace BLL.Services.Impl
{
    //so since im using LoadResult, you'll use Service - just like in the assignments
    public class UsersServiceImpl : LoadResult, IDBOperations<User, UserDTO>
    {
        public UsersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {

        }

        public async Task<LoadResult> Create(User type)
        {
            bool userExists = HyperplayRealmDBContext.Users.Select(u => u.Username == type.Username || u.Email == type.Email).Any();
            Console.WriteLine(type.ToString());

            if (userExists)
            {
                return (LoadResult) await Load(ResultEnum.ERROR, false);
            }

            HyperplayRealmDBContext.Users.Add(type);
            await HyperplayRealmDBContext.SaveChangesAsync();
            return (LoadResult)await Load(ResultEnum.SUCCESS, true);
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
