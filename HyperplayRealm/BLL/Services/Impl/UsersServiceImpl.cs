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
        public UsersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {

        }

        public Task<ILoadResult> Create(User type)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Update(User type)
        {
            throw new NotImplementedException();
        }
    }
}
