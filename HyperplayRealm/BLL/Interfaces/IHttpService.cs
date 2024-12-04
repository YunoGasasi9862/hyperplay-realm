using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHttpService
    {
        public Task<T> GetSession<T>(string sessionKey) where T : class, new();

        public Task SetSession<T>(string sessionKey, T session) where T : class, new();

        public Task ClearSession();

        public Task RemoveSessionByKey(string sessionKey);  
    }
}
