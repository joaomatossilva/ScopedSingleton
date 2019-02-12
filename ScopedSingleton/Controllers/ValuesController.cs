using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScopedSingleton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SingletonService _singletonService;

        public ValuesController(SingletonService singletonService)
        {
            _singletonService = singletonService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var obj1 = _singletonService.GetScoped();
            obj1.Data.Add("value1");

            var obj2 = _singletonService.GetScoped();
            obj2.Data.Add("value2");

            var obj3 = _singletonService.GetScoped();
            obj3.Data.Add("value3");

            return obj3.Data.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
