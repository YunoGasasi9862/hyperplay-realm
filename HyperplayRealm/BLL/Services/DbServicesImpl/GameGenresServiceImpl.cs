﻿using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GameGenresServiceImpl : LoadResult, IDBOperations<GameGenre, GameGenreDTO>
    {
        public GameGenresServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
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
            return HyperplayRealmDBContext.GameGenres.Select(GameGenreDTO.FromEntity);
        }

        public Task<LoadResult> Update(GameGenre type)
        {
            throw new NotImplementedException();
        }
    }
}
