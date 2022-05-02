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
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItemDto dto)
        {

            var todoItem = new TodoItem
            {
                Name = dto.Name,
                Id = dto.Id,
                IsComplete                                                                                                                                                                                                             = dto.IsComplete
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            //return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }
        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemWithCategoryDto>> GetTodoItem(long id)
        {
            var todoItemfind = await _context.TodoItems.FindAsync(id);
            if (todoItemfind == null)
            {
                return NotFound();
            }
            var todoItemDto = new TodoItemDto
            {
                Id = id,
                Name = todoItemfind.Name,
                IsComplete = todoItemfind.IsComplete
            };


            return Ok(todoItemDto);
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
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();      // errore 400
            }

            //_context.TodoItems.Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;                 with entity

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();     // 201 it's an event action
        }
       
        [HttpPost]
        public IActionResult AddMultiTodoItem(IEnumerable<TodoItemDto> items)
        {
            var todoItems = items.Select(dto => new TodoItem
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Id = dto.Id,
                IsComplete = dto.IsComplete
            })
                .ToList();


            _context.TodoItems.AddRange(todoItems);
            _context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public IActionResult DeleteMultiTodoItem(List<long> IDs)
        {

            var todoitems = _context.TodoItems.Where(i => IDs.Contains(i.Id));
            _context.TodoItems.RemoveRange(todoitems);
            _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItemWithCategoryDto>>
        FilterItem(string Name, bool? complitfilter)
        {
            var query = _context.TodoItems
                .Include(p => p.Category)
                .Where(f => (Name == null || f.Name.Contains(Name)) && (complitfilter == null || f.IsComplete == complitfilter))
                .OrderByDescending(x => x.Id);

            var todoItems = query.AsEnumerable();
            var todoItem = todoItems.Select(dto => new TodoItemWithCategoryDto
            {
                Id =dto.Id  ,
                Name = dto.Name,
                IsComplete = dto.IsComplete

            }).ToList();

            return Ok(todoItem);  
        }
    }


    
}




