using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;
using BLL.Enums;

namespace BLL.Services.Impl
{
    public class GamesServiceImpl : LoadResult, IDBOperations<Game, GameDTO>
    {
        public GamesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public async Task<ILoadResult> Create(Game type)
        {
            HyperplayRealmDBContext.Games.Add(type);

            await HyperplayRealmDBContext.SaveChangesAsync();

            return await Load(Result.SUCCESS);
        }

        public Task<ILoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Update(Game type)
        {
            throw new NotImplementedException();
        }

        IQueryable<GameDTO> IDBOperations<Game, GameDTO>.Query()
        {
            throw new NotImplementedException();
        }
    }
}
