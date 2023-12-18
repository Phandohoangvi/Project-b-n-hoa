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
    public class CategoryController : ControllerBase
    {
        QLBanHoaContext da = new QLBanHoaContext();

        // GET: api/<CategoryController>


        [HttpGet("{all cate}")]
        public IActionResult GetAll()
        {
            var ds = da.Categories.ToList();
            return Ok(ds);
        }

        [HttpPost("{all cate Post}")]
        public IActionResult GetAllCategory2()
        {
            var ds = da.Categories.Select(s => new { s.CategoryId, s.CategoryName, s.Description }).ToList();
            return Ok(ds);
        }

        [HttpGet("{cate by id}")]
        public IActionResult GetCategoryById(string id)
        {
            var ds = da.Categories.FirstOrDefault(s => s.CategoryId == id);
            return Ok(ds);

        }
    }
}
