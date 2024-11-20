using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class PurchasesServiceImpl : LoadResult, IDBOperations<Purchase, PurchaseDTO>
    {
        public PurchasesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {
        }

        public Task<LoadResult> Create(Purchase type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PurchaseDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(Purchase type)
        {
            throw new NotImplementedException();
        }
    }
}
