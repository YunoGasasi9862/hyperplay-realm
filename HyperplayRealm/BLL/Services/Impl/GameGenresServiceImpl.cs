using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GameGenresServiceImpl : LoadResult, IDBOperations<GameGenre, GameGenreDTO>
    {
        public GameGenresServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public Task<LoadResult> Create(GameGenre type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GameGenreDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(GameGenre type)
        {
            throw new NotImplementedException();
        }
    }
}
