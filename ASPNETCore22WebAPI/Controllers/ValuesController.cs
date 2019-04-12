using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore22WebAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore22WebAPI.Controllers
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
            return Ok(thing.ProduceValues());
        }
    }
}
