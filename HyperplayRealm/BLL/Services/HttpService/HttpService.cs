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
        protected readonly IHttpContextAccessor _httpContextAccessor;
        public HttpService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual Task<T> GetSession<T>(string sessionKey) where T : class, new()
        {
            string? json = _httpContextAccessor?.HttpContext?.Session.GetString(sessionKey);

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return Task.FromResult(JsonConvert.DeserializeObject<T>(json));

        }

        public Task RemoveSessionByKey(string sessionKey)
        {
            _httpContextAccessor?.HttpContext?.Session.Remove(sessionKey);

            return Task.CompletedTask;
        }

        public Task ClearSession()
        {
            _httpContextAccessor?.HttpContext?.Session.Clear();

            return Task.CompletedTask;
        }

        public Task SetSession<T>(string sessionKey, T session) where T : class, new()
        {
            string json = JsonConvert.SerializeObject(sessionKey);

            _httpContextAccessor?.HttpContext?.Session.SetString(sessionKey, json);

            return Task.CompletedTask;
        }
    }
}
