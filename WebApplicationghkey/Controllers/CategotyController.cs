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
    public class CategotyController : Controller
    {
        private readonly TodoContext _context;
        public CategotyController(TodoContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult PostCategory(Category dto)
        {
            var categoryItem = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Order = dto.Order
            };

            _context.CategoryItems.Add(categoryItem);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategory(CategoryDto dto)
        {
            var categoryItem = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Order = dto.Order
            };
            var query = _context.CategoryItems.AsQueryable();

            if (dto.Name != null)
            {
                query=query.Where(x => x.Name.Contains(dto.Name));
            }
            query = query.OrderBy(x => x.Order);
            
            var categories = query.AsEnumerable();
            return View(categories);

        }
        [HttpDelete]
        public ActionResult<IEnumerable<Category>> DeleteCategory(CategoryDto dto)
        {
            var categoryItem = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                Order = dto.Order
            };
            //MyTestClass.Add("lss", "sdfs");
            var categoryid=_context.CategoryItems.Find(dto.Id);
            _context.CategoryItems.Remove(categoryid);
            _context.SaveChanges();
            return View() ;
        }
    }
}
