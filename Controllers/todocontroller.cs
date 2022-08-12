using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using W1.Models;

namespace W1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        public TodoController(TodoContext context){
             _context = context;              
                if (_context.TodoItems.Count() == 0)
                {                 
                _context.TodoItems.Add(new todoitem { desc = "Item1" });
                _context.SaveChanges();             
                }         
        }
        [HttpGet] 
        public ActionResult<List<todoitem>> GetAll() 
        {     
        return _context.TodoItems.ToList(); 
        } 
        
        [HttpGet("{id}", Name = "GetTodo")] 
        public ActionResult<todoitem> GetById(int id) 
        {    
        var item = _context.TodoItems.Find(id);     
        if (item == null)    
        {         
        return NotFound();     
        }     
        return item; 
        }
        [HttpPost]
        public ActionResult Post(todoitem t1){
            _context.TodoItems.Add(t1);
            _context.SaveChanges();      
            return Ok();
        }
        [HttpPut("{id}")]
    public ActionResult Update(int id,todoitem item)
    {
        if (item == null || item.id!=id)
        {
            return BadRequest();
        }

        var supplier = _context.TodoItems.Find(id);
        if (supplier == null)
        {
            return NotFound();
        }

        supplier.desc = item.desc;

        _context.TodoItems.Update(supplier);
        _context.SaveChanges();
        return Ok();
    }
    }
}
