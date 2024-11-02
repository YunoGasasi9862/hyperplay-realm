using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class PurchasesServiceImpl : LoadResult, IDBOperations<Purchase, PurchaseDTO>
    {
        public PurchasesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public Task<ILoadResult> Create(Purchase type)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PurchaseDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Update(Purchase type)
        {
            throw new NotImplementedException();
        }
    }
}
