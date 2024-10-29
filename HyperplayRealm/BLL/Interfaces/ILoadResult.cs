using BLL.Enums;
using BLL.Load;

namespace BLL.Interfaces
{
    public interface ILoadResult
    {
        public Task<string> LoadResult(Result result);
    }
}
