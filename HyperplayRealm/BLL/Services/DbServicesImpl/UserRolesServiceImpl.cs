using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class UserRolesServiceImpl : LoadResult, IDBOperations<UserRole, UserDTO>
    {
        public UserRolesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {
        }

        public Task<LoadResult> Create(UserRole type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(UserRole type)
        {
            throw new NotImplementedException();
        }
    }
}
