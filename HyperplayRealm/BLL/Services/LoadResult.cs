using BLL.Enums;
using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using System.Threading.Tasks;

namespace BLL.Services
{
    //this is similar to what Hocam created but with Service/base Service - i just divided that into enum and Result messages for modularity
    public abstract class LoadResult : ILoadResult
    {
        protected HyperplayRealmDBContext HyperplayRealmDBContext { get; set; }
        protected ResultMessages ResultMessages { get; set; }

        public LoadResult(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages)
        {
            HyperplayRealmDBContext = hyperplayRealmDBContext;

            ResultMessages = resultMessages;
        }

        public Task<LoadResult> Load(Result result)
        {
            ResultMessages.SetResultMessage(result);

            return Task.FromResult(this);
        }
    }
}
