using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetWebAPI.Models;

namespace DotNetWebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<InventoryItem> Get()
        {
            return new InventoryItem("INV6", "Helmet", 12, true);
        }
    }
}
