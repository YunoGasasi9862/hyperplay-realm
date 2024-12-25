using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;
using BLL.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Impl
{
    public class GamesServiceImpl : LoadResult, IDBOperations<Game, GameDTO>
    {
        public GamesServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {
        }

        public async Task<LoadResult> Create(Game type)
        {
            Game? game = HyperplayRealmDBContext.Games.Where(g => g.Title == type.Title).SingleOrDefault();

            if (game != null)
            {
                return (LoadResult)await Load(ResultEnum.ENTITY_ALREADY_EXISTS, false);
            }

            HyperplayRealmDBContext.Games.Add(type);

            await HyperplayRealmDBContext.SaveChangesAsync();

            return (LoadResult) await Load(ResultEnum.SUCCESS, true);
        }

        public async Task<LoadResult> Delete(int id)
        {
            Game? entity = HyperplayRealmDBContext.Games.Include(gg => gg.GameGenres).Include(gd => gd.GameDevelopers).Where(game => game.Id == id).SingleOrDefault();

            if (entity == null)
            {
                return (LoadResult)await Load(ResultEnum.ERROR, false);
            }

            HyperplayRealmDBContext.RemoveRange(entity.GameGenres);
            HyperplayRealmDBContext.RemoveRange(entity.GameDevelopers);
            HyperplayRealmDBContext.Remove(entity);
            await HyperplayRealmDBContext.SaveChangesAsync();

            return (LoadResult)await Load(ResultEnum.SUCCESS, true);
        }

        public Task<LoadResult> Update(Game type)
        {
            throw new NotImplementedException();
        }

        IQueryable<GameDTO> IDBOperations<Game, GameDTO>.Query()
        {
            return HyperplayRealmDBContext.Games.Include(g => g.GameGenres).Include(d => d.GameDevelopers).Select(GameDTO.FromEntity);
        }

    }
}
