using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class UserRolesServiceImpl : LoadResult, IDBOperations<UserRole, UserDTO>
    {
        public UserRolesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public Task<ILoadResult> Create(UserRole type)
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

        public Task<ILoadResult> Update(UserRole type)
        {
            throw new NotImplementedException();
        }
    }
}
