using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ScopedSingleton
{
    public class ScopedObjectRequestFilter : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _accessor;

        public ScopedObjectRequestFilter(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _accessor.HttpContext.Items["scopedObject"] = new ScopedObject();
        }
    }
}
