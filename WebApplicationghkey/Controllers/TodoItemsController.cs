using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationghkey.Models;

namespace WebApplicationghkey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        [Route("api/[controller]")]

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            //return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }
        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }
       
        [HttpPost]
        public IActionResult AddMultiTodoItem(IEnumerable<TodoItem> todoItems)
        {

            _context.TodoItems.AddRange(todoItems);
            _context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public IActionResult DeletMultiTodoItem(List<long> IDs)
        {
            var todoitems = _context.TodoItems.Where(i => IDs.Contains(i.Id));
            _context.TodoItems.RemoveRange(todoitems);
            _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>>
        FilterItem(string Name, bool? complitfilter)
        {
            var query = _context.TodoItems.AsQueryable();

            if (Name != null)
            {
                query = query.Where(f => f.Name.Contains(Name) );

            }
            if (complitfilter != null)
            {
                query = query.Where(f => f.IsComplete == complitfilter);

            }
            query = query.OrderByDescending(x => x.Id);

            var todoItems = query.AsEnumerable();
            return Ok(todoItems);


        }
    }



}




