using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GenresServiceImpl : LoadResult, IDBOperations<Genre, GenreDTO>
    {
        public GenresServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public Task<ILoadResult> Create(Genre type)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GenreDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Update(Genre type)
        {
            throw new NotImplementedException();
        }
    }
}
