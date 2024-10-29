using BLL.Enums;
using BLL.Load;
using BLL.Services;

namespace BLL.Interfaces
{
    public interface ILoadResult
    {
        public Task<ILoadResult> Load(Result result);
    }
}
