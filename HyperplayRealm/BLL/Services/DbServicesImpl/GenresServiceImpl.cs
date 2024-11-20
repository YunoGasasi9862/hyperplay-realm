using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GenresServiceImpl : LoadResult, IDBOperations<Genre, GenreDTO>
    {
        public GenresServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {
        }

        public Task<LoadResult> Create(Genre type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GenreDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(Genre type)
        {
            throw new NotImplementedException();
        }
    }
}
