using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GameDevelopersServiceImpl : LoadResult, IDBOperations<GameDeveloper, GameDeveloperDTO>
    {
        public GameDevelopersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }

        public Task<ILoadResult> Create(GameDeveloper type)
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GameDeveloperDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<ILoadResult> Update(GameDeveloper type)
        {
            throw new NotImplementedException();
        }
    }
}
