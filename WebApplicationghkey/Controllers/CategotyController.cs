using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationghkey.Models;
using WebApplicationghkey.Test;

namespace WebApplicationghkey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategotyController : Controller
    {
        private readonly TodoContext _context;
        public CategotyController(TodoContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult PostCategory(CategoryDto dto)
        {
            var categoryItem = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Order = dto.Order
            };

            _context.CategoryItems.Add(categoryItem);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories(string name, int order )
        {

            var query = _context.CategoryItems.AsQueryable();

            if (name != null)
            {
                query=query.Where(x => x.Name.Contains(name));
                query=query.Where(x => x.Order.Equals(order));
            }
            query = query.OrderBy(o => o.Id);
            var categories = query.AsEnumerable();
            return Ok(categories);

        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(long id)
        {

            var category = _context.CategoryItems.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);

        }
        [HttpDelete]
        public IActionResult DeleteCategory(long id)
        {
            //MyTestClass.Add("lss", "sdfs");
            var categoryid=_context.CategoryItems.Find(id);
            _context.CategoryItems.Remove(categoryid);
            _context.SaveChanges();
            return Ok() ;
        }
        [HttpPut]
        public IActionResult UpDateCategory(CategoryDto dto)
        {
            //MyTestClass.Add("lss", "sdfs");
            var categoryid = _context.CategoryItems.Find(id);
            _context.CategoryItems.Update(categoryid);
            _context.SaveChanges();
            return Ok();
        }
    }
}
