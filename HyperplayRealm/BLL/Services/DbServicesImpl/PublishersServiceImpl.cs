﻿using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class PublishersServiceImpl : LoadResult, IDBOperations<Publisher, PublisherDTO>
    {
        public PublishersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result) : base(hyperplayRealmDBContext, result)
        {
        }

        public Task<LoadResult> Create(Publisher type)
        {
            throw new NotImplementedException();
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PublisherDTO> Query()
        {
            return HyperplayRealmDBContext.Publishers.Select(PublisherDTO.FromEntity);
        }

        public Task<LoadResult> Update(Publisher type)
        {
            throw new NotImplementedException();
        }
    }
}
