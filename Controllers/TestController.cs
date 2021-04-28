using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<int>> Get()
        {
            return new List<int> { 1, 2, 3, 4 };
        }
    }
}
