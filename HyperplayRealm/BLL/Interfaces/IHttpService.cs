using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHttpService
    {
        public Task<T> GetSession<T>() where T : class, new();

        public Task SetSession<T>(T session) where T : class, new();
    }
}
