using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class RolesServiceImpl : LoadResult, IDBOperations<Role, RoleDTO>
    {
        public RolesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {

        }

        public Task<ILoadResult> Create(Role type)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoleDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Update(Role type)
        {
            throw new NotImplementedException();
        }
    }
}
