using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationghkey.Controllers
{
    public class CategotyController : Controller
    {
        private readonly TodoContext context;
        public CategotyController(TodoContext _context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult PostCategory()
        {
            //_context.
            return View();
        }
    }
}
