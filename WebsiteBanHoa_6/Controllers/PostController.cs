using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBanHoa_6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteBanHoa_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        QLBanHoaContext da = new QLBanHoaContext();

        [HttpGet("{}")]
        public IActionResult GetAll()
        {
            var ds = da.Categories.ToList();
            return Ok(ds);
        }
    }
}
