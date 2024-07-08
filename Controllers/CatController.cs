using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisionDay1.Models;
using VisionDay1.Services;

namespace VisionDay1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : ControllerBase
    {
        private readonly CatService _catService;

        public CatController(CatService catService)
        {
            _catService = catService;
        }

        [HttpGet("GetCatNames")]
        public IEnumerable<Cat> Get()
        {
            return _catService.GetAll();
        }

        [HttpPost("AddCat")]
        public IActionResult Post(Cat newCat)
        {
            _catService.Add(newCat);
            return Ok();
        }
        [HttpPut("UpdateCat")]
        public IActionResult Put(int id, Cat newCat)
        {
            _catService.Update(id, newCat);
            return Ok();
        }

        [HttpDelete("DeleteCat")]

        public IActionResult Delete(int id)
        {
            _catService.DeleteCat(id);
            return Ok();
        }

        [HttpGet("GetOdd")]
        public IEnumerable<Cat> GetOdds()
        {
            return _catService.GetOdd();
        }


        [HttpGet("Pages")]
        public IActionResult boo(int page, int noelements)
        {
            return Ok(_catService.returnPage(page - 1, noelements));
        }

        [HttpGet("{id}")]
        public ActionResult<Cat> GetCatById(int id)
        {
            var cat = _catService.GetById(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }
    }
}
