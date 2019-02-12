using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ScopedSingleton
{
    public class SingletonService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SingletonService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ScopedObject GetScoped()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new Exception("http context is null...");
            }

            var scopedObject = (ScopedObject) _httpContextAccessor.HttpContext.Items["scopedObject"];
            if (scopedObject == null)
            {
                throw new Exception("There is no Scope");
            }

            return scopedObject;
        }
    }
}
