using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopRunner.Entities;

namespace ShopRunner.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ShopRunnerContext _context;
        public CategoryController(ShopRunnerContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            return Ok(category);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.Where(c => c.Id == id)
                .Include(cate => cate.Products)
                .First();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Created($"/get-by.id?id={category.Id}", category);
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return NoContent();

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
