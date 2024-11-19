using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class RolesServiceImpl : LoadResult, IDBOperations<Role, RoleDTO>
    {
        public RolesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, Result result) : base(hyperplayRealmDBContext, result)
        {

        }

        public Task<LoadResult> Create(Role type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoleDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(Role type)
        {
            throw new NotImplementedException();
        }
    }
}
