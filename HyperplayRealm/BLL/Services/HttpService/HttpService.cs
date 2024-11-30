using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.HttpService
{
    public class HttpService : IHttpService
    {
        const string SESSION_KEY = "SESSION_KEY";

        protected readonly IHttpContextAccessor _httpContextAccessor;
        public HttpService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public virtual Task<T> GetSession<T>() where T : class, new()
        {
            string? json = _httpContextAccessor?.HttpContext?.Session.GetString(SESSION_KEY);

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return Task.FromResult(JsonConvert.DeserializeObject<T>(json));

        }

        public Task SetSession<T>(T session) where T : class, new()
        {
            string json = JsonConvert.SerializeObject(session);

            _httpContextAccessor?.HttpContext?.Session.SetString(SESSION_KEY, json);

            return Task.CompletedTask;
        }
    }
}
