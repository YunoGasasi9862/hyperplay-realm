using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class DevelopersServiceImpl : LoadResult, IDBOperations<Developer, DeveloperDTO>
    {
        public DevelopersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {
        }

        public Task<LoadResult> Create(Developer type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(Developer type)
        {
            throw new NotImplementedException();
        }

        IQueryable<DeveloperDTO> IDBOperations<Developer, DeveloperDTO>.Query()
        {
            return HyperplayRealmDBContext.Developers.Select(DeveloperDTO.FromEntity);
        }
    }
}
