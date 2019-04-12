using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomDIWebAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CustomDIWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IThing thing;

        public ValuesController(IThing thing)
        {
            this.thing = thing;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
