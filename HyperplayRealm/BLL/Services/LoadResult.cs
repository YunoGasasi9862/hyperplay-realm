using BLL.Enums;
using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using System.Threading.Tasks;

namespace BLL.Services
{
    //this is similar to what Hocam created but with Service/base Service - i just divided that into enum and Result messages for modularity
    public class LoadResult : ILoadResult
    {
        protected HyperplayRealmDBContext HyperplayRealmDBContext { get; set; }
        public IResult Result { get; set; }

        public LoadResult(HyperplayRealmDBContext hyperplayRealmDBContext, IResult result)
        {
            HyperplayRealmDBContext = hyperplayRealmDBContext;

            Result = result;
        }

        public Task<ILoadResult> Load(ResultEnum result, bool isSuccessful)
        {
            Result.SetResultMessage(result, isSuccessful);

            return Task.FromResult<ILoadResult>(this);
        }
    }
}
