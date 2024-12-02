using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class UserRolesServiceImpl : LoadResult, IDBOperations<UserRole, UserRoleDTO>
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

        public IQueryable<UserRoleDTO> Query()
        {
            return HyperplayRealmDBContext.UserRoles.Select(UserRoleDTO.FromEntity);
        }

        public Task<LoadResult> Update(UserRole type)
        {
            throw new NotImplementedException();
        }
    }
}
