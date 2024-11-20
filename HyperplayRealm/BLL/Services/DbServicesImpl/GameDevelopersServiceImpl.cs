using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GameDevelopersServiceImpl : LoadResult, IDBOperations<GameDeveloper, GameDeveloperDTO>
    {
        public GameDevelopersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {
        }

        public Task<LoadResult> Create(GameDeveloper type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GameDeveloperDTO> Query()
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(GameDeveloper type)
        {
            throw new NotImplementedException();
        }
    }
}
