using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GamesServiceImpl : LoadResult, IDBOperations<Game, GameDTO>
    {
        public GamesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public Task<LoadResult> Create(Game type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GameDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(Game type)
        {
            throw new NotImplementedException();
        }
    }
}
