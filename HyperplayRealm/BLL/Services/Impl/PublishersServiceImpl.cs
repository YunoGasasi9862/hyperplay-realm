using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class PublishersServiceImpl : LoadResult, IDBOperations<Publisher, PublisherDTO>
    {
        public PublishersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public Task<ILoadResult> Create(Publisher type)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PublisherDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Update(Publisher type)
        {
            throw new NotImplementedException();
        }
    }
}
