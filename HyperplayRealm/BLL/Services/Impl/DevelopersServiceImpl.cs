using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class DevelopersServiceImpl : LoadResult, IDBOperations<Developer, DeveloperDTO>
    {
        public DevelopersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public Task<ILoadResult> Create(Developer type)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Update(Developer type)
        {
            throw new NotImplementedException();
        }

        IQueryable<DeveloperDTO> IDBOperations<Developer, DeveloperDTO>.Query()
        {
            throw new NotImplementedException();
        }
    }
}
