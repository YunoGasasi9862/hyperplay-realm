using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.HttpService
{
    public class HttpService : IHttpService
    {
        public Task<T> GetSession<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public Task SetSession<T>(T session) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
