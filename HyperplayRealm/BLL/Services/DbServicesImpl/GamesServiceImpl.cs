using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;
using BLL.Enums;
using System.Linq;

namespace BLL.Services.Impl
{
    public class GamesServiceImpl : LoadResult, IDBOperations<Game, GameDTO>
    {
        public GamesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {
        }

        public async Task<LoadResult> Create(Game type)
        {
            HyperplayRealmDBContext.Games.Add(type);

            await HyperplayRealmDBContext.SaveChangesAsync();

            return (LoadResult) await Load(ResultEnum.SUCCESS, true);
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Update(Game type)
        {
            throw new NotImplementedException();
        }

        IQueryable<GameDTO> IDBOperations<Game, GameDTO>.Query()
        {
            return HyperplayRealmDBContext.Games.Select(game => new GameDTO().MapFrom(game));
        }

    }
}
